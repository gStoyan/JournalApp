using CommunityToolkit.Mvvm.Input;
using JournalApp.Business.Helpers;
using JournalApp.Business.ViewModels.Base;
using JournalApp.Contracts;
using JournalApp.Contracts.Services;

namespace JournalApp.Business.ViewModels;

public partial class JournalViewModel : PageViewModelBase
{
    private readonly IJournalService _journalService;
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly JournalDto? _journal;
    private readonly IUserSessionContext _userSessionContext;
    private readonly UserDto _user;

    public JournalViewModel(
        UserDto user,
        IUserSessionContext userSessionContext,
        IJournalService journalService,
        MainWindowViewModel mainWindowViewModel,
        JournalDto? journal = null)
    {
        _user = user;
        _userSessionContext = userSessionContext;
        _journalService = journalService;
        _mainWindowViewModel = mainWindowViewModel;
        _journal = journal;
        Title = journal?.Title ?? string.Empty;
        Content = journal?.Content ?? string.Empty;
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public override bool CanNavigateNext { get; protected set; } = false;

    public override bool CanNavigatePrevious { get; protected set; } = true;


    [RelayCommand]
    private async Task Save()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            await MessageBoxHelper.ShowAsync("Save", "Title cannot be empty.");
            return;
        }

        if (string.IsNullOrWhiteSpace(Content))
        {
            await MessageBoxHelper.ShowAsync("Save", "Content cannot be empty.");
            return;
        }

        try
        {
            var journalId = await _journalService.SaveJournal(_journal?.Id, Title, Content, _user.Id);

            if (_journal is null)
            {
                _userSessionContext.CurrentUser?.Journals.Add(new JournalDto
                {
                    Id = journalId,
                    Title = Title,
                    Content = Content,
                    User = _user
                });
            }
            else
            {
                _journal.Title = Title;
                _journal.Content = Content;
            }

            _mainWindowViewModel.NavigateToPage(
                new ProfileViewModel(_mainWindowViewModel, _userSessionContext, _journalService));
        }
        catch (Exception e)
        {
            throw new InvalidOperationException("Failed to save journal entry.", e);
        }
    }
}