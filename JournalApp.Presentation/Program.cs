using System;
using Avalonia;
using JournalApp.Adapter;
using JournalApp.Business;
using JournalApp.Business.ViewModels;
using JournalApp.Infrastructure;
using JournalApp.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;
using Ioc = CommunityToolkit.Mvvm.DependencyInjection.Ioc;

namespace JournalApp.Presentation;

internal sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        var provider = services
            .AddAdapter()
            .AddInfrastructure()
            .AddBusiness()
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<MainWindow>()
            .AddTransient<HomeViewModel>()
            .AddTransient<HomeView>()
            .BuildServiceProvider();


        Ioc.Default.ConfigureServices(provider);

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }


    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    }
}