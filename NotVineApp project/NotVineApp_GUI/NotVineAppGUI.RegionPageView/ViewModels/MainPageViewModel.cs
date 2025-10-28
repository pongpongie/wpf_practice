using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotVineApp.Common.Utils;

namespace NotVineAppGUI.RegionPageView.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private object _currentPageViewModel;
        public object CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPageViewModel()
        {
            // 초기 뷰모델 설정 (예: AuthPageViewModel)
            CurrentPageViewModel = new AuthPageViewModel();
        }
    }
}
