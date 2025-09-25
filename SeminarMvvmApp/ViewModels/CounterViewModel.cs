using SeminarMvvmApp.Utils;

namespace SeminarMvvmApp.ViewModels
{
    public class CounterViewModel : ViewModelBase
    {
        private int _count;
        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }
        public RelayCommand IncrementCommand { get; }
        public RelayCommand DecrementCommand { get; }
        public CounterViewModel()
        {
            IncrementCommand = new RelayCommand(_ => Count++);
            DecrementCommand = new RelayCommand(_ => Count--);
        }
    }
}