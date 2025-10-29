using NotVineAppGUI.HomeModule.ViewModels;
using System.Windows.Controls;
using NotVineApp.Common.Utils;


namespace NotVineAppGUI.HomeModule.Views
{
    /// <summary>
    /// HomeView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView(HomeViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        public HomeView() : this(IoCContainer.Instance.Resolve<HomeViewModel>())
        {
        }
    }
}
