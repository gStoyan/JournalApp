using System.Windows.Input;
using DynamicData;
using JournalApp.Business.ViewModels.Base;
using JournalApp.Contracts.Services;
using ReactiveUI;

namespace JournalApp.Business.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly PageViewModelBase[] _pages;

    private PageViewModelBase _currentPage;
    private string _nextButtonContent = "Login";

    public MainWindowViewModel(IUserService userService, IJournalService journalService)
    {
        _pages =
        [
            new HomeViewModel(userService),
            new LoginViewModel(userService, this, journalService)
        ];

        _currentPage = _pages[0];
        // Create Observables which will activate to deactivate our commands based on CurrentPage state
        var canNavNext = this.WhenAnyValue(x => x.CurrentPage.CanNavigateNext);
        var canNavPrev = this.WhenAnyValue(x => x.CurrentPage.CanNavigatePrevious);

        NavigateNextCommand = ReactiveCommand.Create(NavigateNext, canNavNext, RxApp.MainThreadScheduler);
        NavigatePreviousCommand = ReactiveCommand.Create(NavigatePrevious, canNavPrev, RxApp.MainThreadScheduler);
    }

    public string NextButtonContent
    {
        get => _nextButtonContent;

        set => SetProperty(ref _nextButtonContent, value);
    }

    public PageViewModelBase CurrentPage
    {
        get => _currentPage;
        private set => SetProperty(ref _currentPage, value);
    }

    public ICommand NavigateNextCommand { get; }

    public ICommand NavigatePreviousCommand { get; }

    public void NavigateToPage(PageViewModelBase page)
    {
        CurrentPage = page ?? throw new ArgumentNullException(nameof(page));
    }

    private void NavigateNext()
    {
        var index = _pages.IndexOf(_currentPage) + 1;

        if (index >= _pages.Length) return;
        CurrentPage = _pages[index];

        NextButtonContent = index == 0 ? "Login" : "Continue";
    }


    private void NavigatePrevious()
    {
        var index = _pages.IndexOf(_currentPage) - 1;

        if (index < 0)
        {
            CurrentPage = _pages[0];
            return;
        }

        CurrentPage = _pages[index];
        NextButtonContent = index == 0 ? "Login" : "Continue";
    }
}