namespace JournalApp.Business.Helpers;

public static class MessageBoxHelper
{
    public static async Task ShowAsync(string title, string message)
    {
        var box = MsBox.Avalonia.MessageBoxManager
            .GetMessageBoxStandard(title, message);

        await box.ShowAsync();
    }
}