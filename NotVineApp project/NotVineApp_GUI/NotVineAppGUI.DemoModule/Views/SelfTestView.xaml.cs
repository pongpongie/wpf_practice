using NotVineAppGUI.DemoModule.ViewModels;
using NotVineApp.Common.Services;

using System.Windows.Controls;

namespace NotVineAppGUI.DemoModule.Views
{
    public partial class SelfTestView : UserControl
    {
        public SelfTestView(SelfTestViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        public SelfTestView() : this(ServiceLocator.Instance.Resolve<SelfTestViewModel>())
        {
        }
    }
}
