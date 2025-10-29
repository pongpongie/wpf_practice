using NotVineAppGUI.DemoModule.ViewModels;
using NotVineApp.Common.Utils;

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

        public SelfTestView() : this(IoCContainer.Instance.Resolve<SelfTestViewModel>())
        {
        }
    }
}
