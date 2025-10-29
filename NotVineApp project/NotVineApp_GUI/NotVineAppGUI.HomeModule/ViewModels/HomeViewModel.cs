using NotVineApp.Common.Utils;
using NotVineApp.Common.Services;

namespace NotVineAppGUI.HomeModule.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
