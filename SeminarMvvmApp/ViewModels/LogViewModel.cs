using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using SeminarMvvmApp.Messages;
using System.Collections.ObjectModel;

namespace SeminarMvvmApp.ViewModels
{
    [POCOViewModel]
    public class LogViewModel
    {
        public ObservableCollection<string> Logs { get; } = new();
        public LogViewModel()
        {
            Messenger.Default.Register<NotificationMessage>(OnNotificationReceived);
        }
        private void OnNotificationReceived(NotificationMessage msg)
        {
            Logs.Add(msg.Content);
        }
    }
}