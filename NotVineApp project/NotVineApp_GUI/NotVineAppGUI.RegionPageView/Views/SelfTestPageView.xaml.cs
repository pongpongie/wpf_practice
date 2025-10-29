using NotVineApp.Common.Services;
using NotVineAppGUI.RegionPageView.ViewModels;
using System.Windows.Controls;

namespace NotVineAppGUI.RegionPageView.Views
{
    public partial class SelfTestPageView : UserControl
    {
        public SelfTestPageView()
        {
            InitializeComponent();
            this.DataContext = ServiceLocator.Instance.Resolve<SelfTestPageViewModel>();
        }
    }
}