using DevExpress.Mvvm;
using SeminarMvvmApp.Messages;
using SeminarMvvmApp.Models;

namespace SeminarMvvmApp.ViewModels
{
    public class CounterViewModel : ViewModelBase
    {
        private readonly CounterModel _model;
        public CounterViewModel(CounterModel model)
        {
            _model = model;
            IncrementCommand = new DelegateCommand(Increment);
            DecrementCommand = new DelegateCommand(Decrement);
        }

        public int Count
        {
            get => _model.Count;
            set
            {
                if (_model.Count != value)
                {
                    _model.Count = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DelegateCommand IncrementCommand { get; }
        public DelegateCommand DecrementCommand { get; }

        private void Increment()
        {
            _model.Increment();
            RaisePropertyChanged(nameof(Count));

            if (_model.Count >= 10)
            {
                Messenger.Default.Send(new NotificationMessage($"Count가 10 이상입니다: {_model.Count}"));
            }
        }
        private void Decrement()
        {
            _model.Decrement();
            RaisePropertyChanged(nameof(Count));
        }
    }
}