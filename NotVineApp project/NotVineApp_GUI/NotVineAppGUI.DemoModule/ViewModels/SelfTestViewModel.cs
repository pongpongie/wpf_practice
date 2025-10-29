using NotVineApp.Common.Services;
using NotVineApp.Common.Utils;

namespace NotVineAppGUI.DemoModule.ViewModels
{
    public class SelfTestViewModel : ViewModelBase

    {
        private readonly INavigationService _navigationService;
        public SelfTestViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}