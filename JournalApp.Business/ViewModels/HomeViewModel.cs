using CommunityToolkit.Mvvm.Input;
using JournalApp.Business.ViewModels.Base;
using JournalApp.Contracts.Services;

namespace JournalApp.Business.ViewModels;

public partial class HomeViewModel(IUserService userService) : PageViewModelBase
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public override bool CanNavigateNext
    {
        get => true;
        protected set => throw new NotSupportedException();
    }

    public override bool CanNavigatePrevious
    {
        get => true;
        protected set => throw new NotSupportedException();
    }

    [RelayCommand]
    private async Task Register()
    {
        await userService.CreateUserAsync(UserName, Password);
    }
}