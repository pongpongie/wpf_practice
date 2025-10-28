using NotVineAppGUI.LoginModule.ViewModels;
using NotVineApp.Common.Utils;
using System.Windows.Input;

namespace NotVineAppGUI.RegionPageView.ViewModels
{
    public class AuthPageViewModel : ViewModelBase
    {
        public Object CurrentViewModel { get; set; }

        public ICommand ShowLoginFormCommand { get; set; }

        public AuthPageViewModel()
        {
            CurrentViewModel = new LoginFormViewModel();
        }
    }
}
