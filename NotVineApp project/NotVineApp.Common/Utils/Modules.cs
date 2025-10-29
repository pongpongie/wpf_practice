namespace NotVineApp.Common.Utils
{
    public class Module
    {
        public string Key { get; }
        public Func<object> ViewModelFactory { get; }
        public Type ViewType { get; }

        public Module(string key, Func<object> viewModelFactory, Type viewType)
        {
            Key = key;
            ViewModelFactory = viewModelFactory;
            ViewType = viewType;
        }
    }
}