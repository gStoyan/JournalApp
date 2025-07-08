using CommunityToolkit.Mvvm.Input;
using JournalApp.Business.Helpers;
using JournalApp.Business.ViewModels.Base;
using JournalApp.Contracts.Services;
using MsBox.Avalonia;

namespace JournalApp.Business.ViewModels;

public partial class LoginViewModel(IUserService userService) : PageViewModelBase
{
    private readonly IUserService _userService = userService;

    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

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
    private async Task Login()
    {
        if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
        {
            await MessageBoxHelper.ShowAsync("Login", "Username and password cannot be empty.");
            return;
        }

        try
        {
            var user = await _userService.LoginAsync(UserName, Password);
            await MessageBoxHelper.ShowAsync("Login", $"Welcome {user.UserName}!");
        }
        catch (Exception e)
        {
            throw new InvalidOperationException("Failed to login user.", e);
        }
    }
}