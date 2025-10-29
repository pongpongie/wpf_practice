using NotVineApp.Common.Services;
using NotVineApp.Common.Utils;

namespace NotVineAppGUI.DemoModule.ViewModels
{
    public class UserViewModel : ViewModelBase

    {
        private readonly INavigationService _navigationService;
        public UserViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}