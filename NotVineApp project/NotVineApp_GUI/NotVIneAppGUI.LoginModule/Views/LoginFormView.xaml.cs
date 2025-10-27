using System.Windows.Controls;

namespace NotVineAppGUI.LoginModule.Views
{
    /// <summary>
    /// LoginFormView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginFormView : UserControl
    {
        public LoginFormView()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.LoginFormViewModel();
        }
    }
}
