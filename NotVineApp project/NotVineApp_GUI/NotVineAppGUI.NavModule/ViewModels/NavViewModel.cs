using NotVineApp.Common.Utils;
using NotVineApp.Common.Services;

namespace NotVineAppGUI.NavModule.ViewModels
{
    public class NavViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public NavViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
