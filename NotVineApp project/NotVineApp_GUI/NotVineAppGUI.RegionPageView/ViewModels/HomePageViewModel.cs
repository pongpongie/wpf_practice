using NotVineApp.Common.Utils;
using NotVineApp.Common.Services;
using NotVineAppGUI.HomeModule.ViewModels;

namespace NotVineAppGUI.RegionPageView.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public Object CurrentViewModel { get; set; }

        public HomePageViewModel()
        {
            CurrentViewModel = ServiceLocator.Instance.Resolve<HomeViewModel>();
        }
    }

}
