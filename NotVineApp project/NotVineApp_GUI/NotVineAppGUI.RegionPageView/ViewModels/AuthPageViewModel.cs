using NotVineAppGUI.LoginModule.ViewModels;
using NotVineApp.Common.Utils;
using NotVineApp.Common.Services;
using System.Windows.Input;

namespace NotVineAppGUI.RegionPageView.ViewModels
{
    public class AuthPageViewModel : ViewModelBase
    {
        public AuthPageViewModel()
        {
            
        }

        public static AuthPageViewModel Create()
        {
            return new AuthPageViewModel();
        }
    }
}