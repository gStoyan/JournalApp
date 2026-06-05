using CommunityToolkit.Mvvm.Input;
using JournalApp.Business.Helpers;
using JournalApp.Business.ViewModels.Base;
using JournalApp.Domain.Journal;

namespace JournalApp.Business.ViewModels;

public partial class ProfileViewModel : PageViewModelBase
{
    public List<Journal> Journals { get; set; } = new()
    {
        new Journal
        {
            Title = "testing"
        },
        new Journal
        {
            Title = "testing2"
        }
    };

    public Journal SelectedJournal { get; set; }
    public override bool CanNavigateNext { get; protected set; }
    public override bool CanNavigatePrevious { get; protected set; }

    [RelayCommand]
    public async Task OpenJournal(int id)
    {
        await MessageBoxHelper.ShowAsync($"Open Journal {id}",
            "This feature is not implemented yet.");
    }
}