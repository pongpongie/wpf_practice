using NotVineAppGUI.NavModule.ViewModels;
using NotVineApp.Common.Services;

using System.Windows.Controls;

namespace NotVineAppGUI.NavModule.Views
{
    public partial class NavView : UserControl
    {
        public NavView(NavViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        public NavView() : this(ServiceLocator.Instance.Resolve<NavViewModel>())
        {
        }
    }
}
