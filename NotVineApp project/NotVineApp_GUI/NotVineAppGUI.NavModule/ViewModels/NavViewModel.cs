using NotVineApp.Common.Settings;
using NotVineApp.Common.Utils;
using NotVineAppGUI.NavModule.Models;

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
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
        private readonly List<string> _history = new List<string>();
        private int _currentIndex = -1; // -1로 초기화하여 첫 페이지 진입 시 0이 되도록 함
        private bool _isNavigatingHistory = false;

        public NavViewModel()
        {
            Pages = new ObservableCollection<NavPageInfo>
            {
                new NavPageInfo { Title="홈", PageKey=PageViews.HomePageView, IsVisible=true},
                new NavPageInfo { Title="로그인", PageKey=PageViews.AuthPageView, IsVisible=false},
                new NavPageInfo { Title="자가 점검", PageKey=PageViews.SelfTestPageView, IsVisible=true},
                new NavPageInfo { Title="유저 관리", PageKey=PageViews.UserPageView, IsVisible=true},
                new NavPageInfo { Title="분석 보고서", PageKey=PageViews.ReportPageView, IsVisible=true},

            };

            NavigateCommand = new RelayCommand(p => Navigate(p as string));
            GoCommand = new RelayCommand(p => Go(p as string));

            Navigate(PageViews.HomePageView);
        }

        public static NavViewModel Create()
        {
            return new NavViewModel();
        }

        public void Go(string parameter)
        {
            switch (parameter)
            {
                case "Back":
                    if (CanGo("Back"))
                    {
                        _isNavigatingHistory = true;
                        _currentIndex--;
                        string backKey = _history[_currentIndex];
                        Manager.Inject(Regions.MainRegion, backKey);
                        _isNavigatingHistory = false;
                    }
                    break;

                case "Forward":
                    if (CanGo("Forward"))
                    {
                        _isNavigatingHistory = true;
                        _currentIndex++;
                        string forwardKey = _history[_currentIndex];
                        Manager.Inject(Regions.MainRegion, forwardKey);
                        _isNavigatingHistory = false;
                    }
                    break;

                case "Home":
                    // 홈 버튼은 NavigateTo를 재사용 (히스토리 관리 로직 포함)
                    Navigate(PageViews.HomePageView);
                    break;

                case "Exit":
                    Application.Current.Shutdown();
                    break;

            }
        }

        private void Navigate(string parameter)
        {
            if (parameter == null) return;

            if (!_isNavigatingHistory)
            {
                // 현재 페이지와 동일한 페이지로 이동 요청 시 무시
                if (_currentIndex >= 0 && _history[_currentIndex] == parameter)
                {
                    return;
                }

                // (추가) 히스토리 관리
                // 1. 현재 인덱스 뒤에 있는 '미래' 기록 삭제
                if (_currentIndex < _history.Count - 1)
                {
                    _history.RemoveRange(_currentIndex + 1, _history.Count - _currentIndex - 1);
                }

                // 2. 새 기록 추가 및 인덱스 업데이트
                _history.Add(parameter);
                _currentIndex = _history.Count - 1;
            }
            Manager.Inject(Regions.MainRegion, parameter);
        }

        public bool CanGo(string parameter)
        {
            switch (parameter)
            {
                case "Back":
                    return _currentIndex > 0; // 히스토리의 0번째 인덱스보다 뒤에 있어야 함
                case "Forward":
                    return _currentIndex < _history.Count - 1; // 히스토리의 마지막 인덱스보다 앞에 있어야 함
                case "Home":
                    return true;
                default:
                    return true;
            }
        }
    }
}