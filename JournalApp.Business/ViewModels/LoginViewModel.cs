using CommunityToolkit.Mvvm.Input;
using JournalApp.Business.Helpers;
using JournalApp.Business.ViewModels.Base;
using JournalApp.Contracts.Services;

namespace JournalApp.Business.ViewModels;

public partial class LoginViewModel(IUserService userService) : PageViewModelBase
{
    private bool _canNavigateNext;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public override bool CanNavigateNext
    {
        get => _canNavigateNext;
        protected set => SetProperty(ref _canNavigateNext, value);
    }

    public override bool CanNavigatePrevious { get; protected set; } = true;

    [RelayCommand]
    private async Task Login()
    {
        if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
        {
            await MessageBoxHelper.ShowAsync("Login", "Username and password cannot be empty.");
            return;
        }

        try
        {
            var user = await userService.LoginAsync(UserName, Password);
            await MessageBoxHelper.ShowAsync("Login", $"Welcome {user.UserName}!");
            CanNavigateNext = true;
        }
        catch (Exception e)
        {
            throw new InvalidOperationException("Failed to login user.", e);
        }
    }
}