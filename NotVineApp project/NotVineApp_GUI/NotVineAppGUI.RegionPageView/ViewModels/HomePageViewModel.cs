using NotVineApp.Common.Utils;
using NotVineApp.Common.Services;
using NotVineAppGUI.HomeModule.ViewModels;
using NotVineAppGUI.NavModule.ViewModels;


namespace NotVineAppGUI.RegionPageView.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public Object HomeViewModel { get; set; }
        public Object NavViewModel { get; set; }

        public HomePageViewModel()
        {
            HomeViewModel = IoCContainer.Instance.Resolve<HomeViewModel>();
            NavViewModel = IoCContainer.Instance.Resolve<NavViewModel>();
        }
    }

}
