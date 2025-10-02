using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using SeminarMvvmApp.Messages;
using SeminarMvvmApp.Models;
using SeminarMvvmApp.Utils;
using System.Diagnostics;

namespace SeminarMvvmApp.ViewModels
{
    [POCOViewModel] // [POCOViewModel] 특성을 사용하여 이 클래스가 POCO ViewModel임을 명시한다.
    public class CounterViewModel
    {
        private readonly CounterModel _model;
        public CounterViewModel(CounterModel model)
        {
            _model = model;
            Count = _model.Count;
        }

        public virtual int Count { get; set; }

        public void Increment()
        {
            _model.Increment();
            Count = _model.Count;

            if (Count >= 10)
            {
                Messenger.Default.Send(new NotificationMessage($"Count가 10 이상입니다: {Count}"));
            }
        }

        public void Decrement()
        {
            _model.Decrement();
            Count = _model.Count;
        }
    }
}
