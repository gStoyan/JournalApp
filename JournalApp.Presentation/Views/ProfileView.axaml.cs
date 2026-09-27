using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using JournalApp.Business.ViewModels;
using JournalApp.Contracts;
using System.Linq;

namespace JournalApp.Presentation.Views;

public partial class ProfileView : UserControl
{
    public ProfileView()
    {
        InitializeComponent();
    }

    private void JournalCard_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is Button { DataContext: JournalDto journal, ContextMenu: { } contextMenu } &&
            contextMenu.Items.OfType<MenuItem>().FirstOrDefault() is { } deleteItem)
            deleteItem.CommandParameter = journal;
    }

    private async void DeleteJournal_Click(object? sender, RoutedEventArgs e)
    {
        if (DataContext is ProfileViewModel viewModel &&
            sender is MenuItem { CommandParameter: JournalDto journal })
            await viewModel.DeleteJournal(journal);
    }
}