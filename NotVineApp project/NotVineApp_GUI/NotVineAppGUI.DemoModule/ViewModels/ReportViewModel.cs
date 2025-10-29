using NotVineApp.Common.Services;
using NotVineApp.Common.Utils;

namespace NotVineAppGUI.DemoModule.ViewModels
{
    public class ReportViewModel : ViewModelBase

    {
        private readonly INavigationService _navigationService;
        public ReportViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}