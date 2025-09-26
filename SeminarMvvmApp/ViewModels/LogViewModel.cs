using SeminarMvvmApp.Messages;
using SeminarMvvmApp.Utils;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SeminarMvvmApp.ViewModels
{
    public class LogViewModel : ViewModelBase
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