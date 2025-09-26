using System.Windows.Controls;
using SeminarMvvmApp.ViewModels;

namespace SeminarMvvmApp.Views
{
    public partial class LogView : UserControl
    {
        public LogView()
        {
            InitializeComponent();
            DataContext = new LogViewModel();
        }
    }
}
