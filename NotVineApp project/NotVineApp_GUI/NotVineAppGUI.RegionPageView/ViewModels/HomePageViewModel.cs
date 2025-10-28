using NotVineApp.Common.Utils;
using NotVineAppGUI.HomeModule.ViewModels;

namespace NotVineAppGUI.RegionPageView.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public Object CurrentViewModel { get; set; }

        public HomePageViewModel()
        {
            CurrentViewModel = new HomeViewModel();
        }
    }

}
