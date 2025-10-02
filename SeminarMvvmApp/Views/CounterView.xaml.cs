using DevExpress.Mvvm.POCO;
using System.Windows.Controls;

namespace SeminarMvvmApp.Views
{
    public partial class CounterView : UserControl
    {
        public CounterView()
        {
            InitializeComponent();
            this.DataContext = ViewModelSource.Create(() => new ViewModels.CounterViewModel(new Models.CounterModel()));
        }
    }
}
