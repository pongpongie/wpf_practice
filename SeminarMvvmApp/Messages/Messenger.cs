public class Messenger
{
    private static Messenger _instance;
    public static Messenger Default => _instance ??= new Messenger();
    private readonly Dictionary<Type, List<Action<object>>> _subscribers = new();

    public void Register<T>(Action<T> action)
    {
        var type = typeof(T);
        if (!_subscribers.ContainsKey(type))
            _subscribers[type] = new List<Action<object>>();
        _subscribers[type].Add(o => action((T)o));
    }
    public void Send<T>(T message)
    {
        var type = typeof(T);
        if (_subscribers.ContainsKey(type))
            foreach (var action in _subscribers[type])
                action(message);
    }
}