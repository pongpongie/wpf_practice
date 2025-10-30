using NotVineApp.Common.Settings;
using NotVineApp.Common.Utils;
using NotVineAppGUI.NavModule.Models;

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace NotVineAppGUI.NavModule.ViewModels
{
    public class NavViewModel : ViewModelBase
    {
        public ModuleManager Manager => ModuleManager.DefaultManager;

        public ICommand NavigateCommand { get; }
        public ICommand GoCommand { get; }

        public ObservableCollection<NavPageInfo> Pages { get; }


        // 간단한 내비 히스토리
        private readonly List<string> _history = new();
        private int _historyIndex = -1;

        public NavViewModel()
        {
            Pages = new ObservableCollection<NavPageInfo>
            {
                new NavPageInfo { Title="홈", PageKey=PageViews.HomePageView, IsVisible=false},
                new NavPageInfo { Title="로그인", PageKey=PageViews.AuthPageView, IsVisible=true},
                new NavPageInfo { Title="자가 점검", PageKey=PageViews.SelfTestPageView, IsVisible=true},
                new NavPageInfo { Title="유저 관리", PageKey=PageViews.UserPageView, IsVisible=true},
                new NavPageInfo { Title="분석 보고서", PageKey=PageViews.ReportPageView, IsVisible=true},

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
            var cmd = parameter as string;
            if (string.IsNullOrWhiteSpace(cmd)) return;

            switch (cmd)
            {
                case "Back":
                    if (_historyIndex > 0)
                    {
                        _historyIndex--;
                        var key = _history[_historyIndex];
                        Manager.Inject(Regions.MainRegion, key);
                    }
                    break;

                case "Forward":
                    if (_historyIndex >= 0 && _historyIndex < _history.Count - 1)
                    {
                        _historyIndex++;
                        var key = _history[_historyIndex];
                        Manager.Inject(Regions.MainRegion, key);
                    }
                    break;

                case "Home":
                    Navigate(new NavPageInfo { PageKey = PageViews.HomePageView, Title = "홈" });
                    break;

                case "Exit":
                    Application.Current.Shutdown();
                    break;
            }
        }

        private void Navigate(object parameter)
        {
            if (parameter is not NavPageInfo page || string.IsNullOrWhiteSpace(page.PageKey))
                return;

            var key = page.PageKey;

            // 동일 페이지 연속 내비 방지
            if (_historyIndex >= 0 && _history[_historyIndex] == key)
                return;

            // 앞으로 가기 히스토리 컷
            if (_historyIndex < _history.Count - 1 && _historyIndex >= 0)
            {
                _history.RemoveRange(_historyIndex + 1, _history.Count - _historyIndex - 1);
            }

            _history.Add(key);
            _historyIndex = _history.Count - 1;

            Manager.Inject(Regions.MainRegion, key);
        }
    }
}
