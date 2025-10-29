using System.Windows.Controls;
using NotVineAppGUI.RegionPageView.ViewModels;
using NotVineApp.Common.Utils;

namespace NotVineAppGUI.RegionPageView.Views
{
    /// <summary>
    /// AuthPageView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AuthPageView : UserControl
    {
        public AuthPageView()
        {
            InitializeComponent();
            this.DataContext = IoCContainer.Instance.Resolve<AuthPageViewModel>();
        }
    }
}