using NotVineApp.Common.Services;
using NotVineAppGUI.RegionPageView.ViewModels;
using System.Windows.Controls;

namespace NotVineAppGUI.RegionPageView.Views
{
    public partial class HomePageView : UserControl
    {
        public HomePageView()
        {
            InitializeComponent();
            this.DataContext = ServiceLocator.Instance.Resolve<HomePageViewModel>();
        }
    }
}