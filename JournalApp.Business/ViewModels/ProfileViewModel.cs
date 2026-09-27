using CommunityToolkit.Mvvm.Input;
using JournalApp.Business.Helpers;
using JournalApp.Business.ViewModels.Base;
using JournalApp.Contracts;
using JournalApp.Contracts.Services;
using System.Collections.ObjectModel;

namespace JournalApp.Business.ViewModels;

public partial class ProfileViewModel : PageViewModelBase
{
    private readonly IJournalService _journalService;
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly IUserSessionContext _userSessionContext;

    public ProfileViewModel(
        MainWindowViewModel mainWindowViewModel,
        IUserSessionContext userSessionContext,
        IJournalService journalService)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _userSessionContext = userSessionContext;
        _journalService = journalService;
        Journals = new ObservableCollection<JournalDto>(userSessionContext.CurrentUser?.Journals ?? []);
    }

    public ObservableCollection<JournalDto> Journals { get; }

    public JournalDto? SelectedJournal { get; set; }
    public override bool CanNavigateNext { get; protected set; }
    public override bool CanNavigatePrevious { get; protected set; } = true;

    [RelayCommand]
    public Task OpenJournal(int id)
    {
        var user = _userSessionContext.CurrentUser;
        var journal = user?.Journals.FirstOrDefault(item => item.Id == id);

        if (user is null || journal is null)
            return Task.CompletedTask;

        _mainWindowViewModel.NavigateToPage(
            new JournalViewModel(user, _userSessionContext, _journalService, _mainWindowViewModel, journal));
        return Task.CompletedTask;
    }

    [RelayCommand]
    public Task CreateJournal()
    {
        var user = _userSessionContext.CurrentUser;
        if (user is null)
            return Task.CompletedTask;

        _mainWindowViewModel.NavigateToPage(
            new JournalViewModel(user, _userSessionContext, _journalService, _mainWindowViewModel));
        return Task.CompletedTask;
    }

    [RelayCommand]
    public async Task DeleteJournal(JournalDto? journal)
    {
        var user = _userSessionContext.CurrentUser;

        if (user is null || journal is null)
            return;

        try
        {
            await _journalService.DeleteJournal(journal.Id);

            user.Journals.Remove(journal);
            Journals.Remove(journal);
        }
        catch (Exception e)
        {
            await MessageBoxHelper.ShowAsync("Delete Journal", "Failed to delete journal.");
            throw new InvalidOperationException("Failed to delete journal entry.", e);
        }
    }
}