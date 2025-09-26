using SeminarMvvmApp.Models;
using SeminarMvvmApp.Utils;

namespace SeminarMvvmApp.ViewModels
{
    public class CounterViewModel : ViewModelBase
    {
        private readonly CounterModel _model;
        public CounterViewModel(CounterModel model)
        {
            _model = model;
            IncrementCommand = new RelayCommand(_ => Increment());
            DecrementCommand = new RelayCommand(_ => Decrement());
        }

        public int Count
        {
            get => _model.Count;
            set
            {
                if (_model.Count != value)
                {
                    _model.Count = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand IncrementCommand { get; }
        public RelayCommand DecrementCommand { get; }

        private void Increment()
        {
            _model.Increment();
            OnPropertyChanged(nameof(Count));
        }
        private void Decrement()
        {
            _model.Decrement();
            OnPropertyChanged(nameof(Count));
        }
    }
}
