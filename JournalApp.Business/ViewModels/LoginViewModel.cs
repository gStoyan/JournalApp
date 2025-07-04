using CommunityToolkit.Mvvm.Input;
using JournalApp.Business.ViewModels.Base;
using MsBox.Avalonia;

namespace JournalApp.Business.ViewModels;

public partial class LoginViewModel : PageViewModelBase
{
    public string UserName { get; set; }
    public string Password { get; set; }

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
        if (UserName is "admin" && Password is "password")
            await ShowAsync("Login successful");
        else
            await ShowAsync("Login failed");
    }

    private async Task ShowAsync(string message)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Login",
            message);

        await box.ShowAsync();
    }
}