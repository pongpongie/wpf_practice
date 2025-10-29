using NotVineApp.Common.Utils;
using NotVineApp.Common.Services;
using NotVineAppGUI.NavModule.Models;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NotVineAppGUI.NavModule.ViewModels
{
    public class NavViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand NavigateCommand { get; }
        public ICommand GoCommand { get; }

        public ObservableCollection<NavPageInfo> Pages { get; }

        public NavViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Pages = new ObservableCollection<NavPageInfo>
            {
                new NavPageInfo { Title="홈", PageKey="Home", IsVisible=true},
                new NavPageInfo { Title="로그인", PageKey="AuthPage", IsVisible=true},
            };

            NavigateCommand = new RelayCommand(Navigate);
            GoCommand = new RelayCommand(Go);

        }

        private void Go(object parameter)
        {

        }

        private void Navigate(object parameter)
        {
            if (parameter is NavPageInfo page)
                _navigationService.NavigateTo(page.PageKey);

        }
    }
}
