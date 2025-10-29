using System.Windows.Controls;
using NotVineAppGUI.RegionPageView.ViewModels;
using NotVineApp.Common.Services;

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
            // ViewModel을 ServiceLocator를 통해 설정 (선택사항)
            this.DataContext = ServiceLocator.Instance.Resolve<AuthPageViewModel>();
        }
    }
}