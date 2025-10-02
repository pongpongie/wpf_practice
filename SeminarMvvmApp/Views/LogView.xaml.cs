using System.Windows.Controls;
using DevExpress.Mvvm.POCO;
using SeminarMvvmApp.ViewModels;

namespace SeminarMvvmApp.Views
{
    public partial class LogView : UserControl
    {
        public LogView()
        {
            InitializeComponent();
            this.DataContext = ViewModelSource.Create(() => new LogViewModel());
        }
    }
}
