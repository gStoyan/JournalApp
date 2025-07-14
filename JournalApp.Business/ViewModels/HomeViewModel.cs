using CommunityToolkit.Mvvm.Input;
using JournalApp.Business.Helpers;
using JournalApp.Business.ViewModels.Base;
using JournalApp.Contracts.Services;

namespace JournalApp.Business.ViewModels;

public partial class HomeViewModel(IUserService userService) : PageViewModelBase
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;

    public override bool CanNavigateNext { get; protected set; } = true;

    public override bool CanNavigatePrevious { get; protected set; } = false;

    [RelayCommand]
    private async Task Register()
    {
        if (string.IsNullOrWhiteSpace(UserName) ||
            string.IsNullOrWhiteSpace(Password) ||
            string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            await MessageBoxHelper.ShowAsync("Register", "Username, password, and confirm password cannot be empty.");
            return;
        }

        if (Password != ConfirmPassword)
        {
            await MessageBoxHelper.ShowAsync("Register", "Passwords do not match.");
            return;
        }

        try
        {
            await userService.CreateUserAsync(UserName, Password);
            await MessageBoxHelper.ShowAsync("Register", "User registered successfully.");
        }
        catch (Exception e)
        {
            throw new InvalidOperationException("Failed to register user.", e);
        }
    }
}