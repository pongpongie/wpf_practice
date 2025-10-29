using NotVineAppGUI.LoginModule.ViewModels;
using NotVineApp.Common.Utils;
using NotVineApp.Common.Services;
using System.Windows.Input;

namespace NotVineAppGUI.RegionPageView.ViewModels
{
    public class AuthPageViewModel : ViewModelBase
    {
        public Object CurrentViewModel { get; set; }

        public AuthPageViewModel()
        {
            // IoCContainer를 통해 의존성 주입된 ViewModel 가져오기
            CurrentViewModel = IoCContainer.Instance.Resolve<AuthPageViewModel>();
        }
    }
}