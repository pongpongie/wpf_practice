using System.Windows.Controls;
using SeminarMvvmApp.ViewModels;
using SeminarMvvmApp;

namespace SeminarMvvmApp.Views
{
    public partial class CounterView : UserControl
    {
        public CounterView()
        {
            InitializeComponent();
            DataContext = App.Container.Resolve<CounterViewModel>(); // IoC에서 주입
        }
    }
}
