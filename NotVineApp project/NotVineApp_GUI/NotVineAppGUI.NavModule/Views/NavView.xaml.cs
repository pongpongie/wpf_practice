using NotVineAppGUI.NavModule.ViewModels;
using NotVineApp.Common.Utils;

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

        public NavView() : this(IoCContainer.Instance.Resolve<NavViewModel>())
        {
        }
    }
}
