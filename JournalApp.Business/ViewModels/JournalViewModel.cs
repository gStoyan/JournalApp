using CommunityToolkit.Mvvm.Input;
using JournalApp.Business.Helpers;
using JournalApp.Business.ViewModels.Base;
using JournalApp.Contracts;
using JournalApp.Contracts.Services;

namespace JournalApp.Business.ViewModels;

public partial class JournalViewModel(UserDto user, IJournalService journalService) : PageViewModelBase
{
    public string Content { get; set; } = user.Journals.Count > 0 ? user.Journals[0].Content : string.Empty;
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
            await journalService.SaveJournal(Content, user.Id);
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