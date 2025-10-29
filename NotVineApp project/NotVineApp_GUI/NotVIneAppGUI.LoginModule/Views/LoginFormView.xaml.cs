using System.Windows.Controls;
using NotVineAppGUI.LoginModule.ViewModels;
using NotVineApp.Common.Utils;

namespace NotVineAppGUI.LoginModule.Views
{
    public partial class LoginFormView : UserControl
    {
        // DI용 생성자
        public LoginFormView(LoginFormViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        // XAML용 기본 생성자
        public LoginFormView() : this(IoCContainer.Instance.Resolve<LoginFormViewModel>())
        {
        }
    }
}