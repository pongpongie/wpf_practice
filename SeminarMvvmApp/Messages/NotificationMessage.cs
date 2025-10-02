namespace SeminarMvvmApp.Messages
{
    public class NotificationMessage
    {
        public string Content { get; }
        public NotificationMessage(string content) => Content = content;
    }
}
