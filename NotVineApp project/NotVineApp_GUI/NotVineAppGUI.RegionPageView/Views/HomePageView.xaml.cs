using NotVineApp.Common.Settings;
using NotVineApp.Common.Utils;
using NotVineAppGUI.RegionPageView.ViewModels;
using System.Windows.Controls;

namespace NotVineAppGUI.RegionPageView.Views
{
    public partial class HomePageView : UserControl
    {
        public HomePageView()
        {
            InitializeComponent();
            this.DataContext = IoCContainer.Instance.Resolve<HomePageViewModel>();

            // Region들 등록 (VinetelMvvm 방식)
            ModuleManager.DefaultManager.RegisterRegion(Regions.HomeRegion, HomeRegion);
            ModuleManager.DefaultManager.RegisterRegion(Regions.NavRegion, NavRegion);
        }
    }
}