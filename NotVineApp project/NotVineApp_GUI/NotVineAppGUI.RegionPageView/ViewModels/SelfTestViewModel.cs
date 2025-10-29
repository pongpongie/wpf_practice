using NotVineApp.Common.Utils;
using NotVineApp.Common.Services;
using NotVineAppGUI.DemoModule.ViewModels;
using NotVineAppGUI.NavModule.ViewModels;


namespace NotVineAppGUI.RegionPageView.ViewModels
{
    public class SelfTestPageViewModel : ViewModelBase
    {
        public Object SelfTestViewModel { get; set; }
        public Object NavViewModel { get; set; }

        public SelfTestPageViewModel()
        {
            SelfTestViewModel = IoCContainer.Instance.Resolve<SelfTestViewModel>();
            NavViewModel = IoCContainer.Instance.Resolve<NavViewModel>();
        }
    }

}
