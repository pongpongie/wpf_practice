using DevExpress.Mvvm.POCO;

namespace SeminarMvvmApp.ViewModels
{
    public partial class CounterPageViewModel
    {
        protected CounterPageViewModel()
        {
        }

        public static CounterPageViewModel Create()
        {
            return ViewModelSource.Create(() => new CounterPageViewModel());
        }
    }
}
