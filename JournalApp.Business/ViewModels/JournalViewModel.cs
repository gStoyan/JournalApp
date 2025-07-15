using CommunityToolkit.Mvvm.Input;
using JournalApp.Business.Helpers;
using JournalApp.Business.ViewModels.Base;
using JournalApp.Contracts;
using JournalApp.Contracts.Services;

namespace JournalApp.Business.ViewModels;

public partial class JournalViewModel : PageViewModelBase
{
    private readonly IJournalService _journalService;
    private readonly UserDto _user;

    public JournalViewModel(UserDto user, IJournalService journalService)
    {
        _user = user ?? throw new ArgumentNullException(nameof(user));
        _journalService = journalService;
        Content = "Welcome to your journal, " + _user.UserName + "!";
    }

    public string Content { get; set; }
    public override bool CanNavigateNext { get; protected set; } = false;

    public override bool CanNavigatePrevious { get; protected set; } = true;


    [RelayCommand]
    private async Task Save()
    {
        if (string.IsNullOrWhiteSpace(Content))
        {
            await MessageBoxHelper.ShowAsync("Save", "Content cannot be empty.");
            return;
        }

        try
        {
            await _journalService.SaveJournal(Content, _user.Id);
            await MessageBoxHelper.ShowAsync("Save", "Journal entry saved successfully.");
        }
        catch (Exception e)
        {
            throw new InvalidOperationException("Failed to save journal entry.", e);
        }
    }

    [RelayCommand]
    private async Task CreateNew()
    {
        throw new NotImplementedException();
    }
}