using NotVineApp.Common.Utils;
using NotVineAppGUI.NavModule.Models;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NotVineAppGUI.NavModule.ViewModels
{
    public class NavViewModel : ViewModelBase
    {


        public ICommand NavigateCommand { get; }
        public ICommand GoCommand { get; }

        public ObservableCollection<NavPageInfo> Pages { get; }

        public NavViewModel()
        {


            Pages = new ObservableCollection<NavPageInfo>
            {
                new NavPageInfo { Title="홈", PageKey="Home", IsVisible=false},
                new NavPageInfo { Title="로그인", PageKey="AuthPage", IsVisible=true},
                new NavPageInfo { Title="자가 점검", PageKey="SelfTestPage", IsVisible=true},
            };

            NavigateCommand = new RelayCommand(Navigate);
            GoCommand = new RelayCommand(Go);

        }

        public static NavViewModel Create()
        {
            return new NavViewModel();
        }

        private void Go(object parameter)
        {

        }

        private void Navigate(object parameter)
        {


        }
    }
}
