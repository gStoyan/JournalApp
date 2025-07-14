using CommunityToolkit.Mvvm.Input;
using JournalApp.Business.ViewModels.Base;

namespace JournalApp.Business.ViewModels;

public partial class JournalViewModel : PageViewModelBase
{
    public string Content { get; set; } = "This is the Journal View";
    public override bool CanNavigateNext { get; protected set; } = true;

    public override bool CanNavigatePrevious { get; protected set; } = true;

    [RelayCommand]
    private async Task Save()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private async Task CreateNew()
    {
        throw new NotImplementedException();
    }
}