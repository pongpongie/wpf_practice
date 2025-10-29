namespace NotVineApp.Common.Utils
{
    public class IoCContainer
    {
        private static IoCContainer? _instance;
        public static IoCContainer Instance => _instance ??= new IoCContainer();

        private readonly Dictionary<Type, Func<object>> _transients = new();
        private readonly Dictionary<Type, object> _singletons = new();

        private IoCContainer() { }

        // Transient 등록: 요청할 때마다 새 인스턴스 생성
        public void RegisterTransient<TService>(Func<TService> factory) where TService : class
        {
            _transients[typeof(TService)] = () => factory();
        }

        // Transient 등록: 기본 생성자로 매번 새 인스턴스 생성
        public void RegisterTransient<TService>() where TService : class, new()
        {
            _transients[typeof(TService)] = () => new TService();
        }

        // Singleton 등록: 인스턴스 직접 등록
        public void RegisterSingleton<TService>(TService instance) where TService : class
        {
            _singletons[typeof(TService)] = instance;
        }

        // Singleton 등록: 팩토리는 나중에 실행 (지연 초기화)
        public void RegisterSingletonLazy<TService>(Func<TService> factory) where TService : class
        {
            _transients[typeof(TService)] = () =>
            {
                if (!_singletons.ContainsKey(typeof(TService)))
                {
                    _singletons[typeof(TService)] = factory();
                }
                return _singletons[typeof(TService)];
            };
        }

        // 해제(선택적)
        public void Unregister<TService>() where TService : class
        {
            _singletons.Remove(typeof(TService));
            _transients.Remove(typeof(TService));
        }

        // Resolve
        public TService Resolve<TService>() where TService : class
        {
            var type = typeof(TService);

            if (_singletons.TryGetValue(type, out var singleton))
                return (TService)singleton;

            if (_transients.TryGetValue(type, out var factory))
                return (TService)factory();

            throw new InvalidOperationException($"{type.Name}이(가) 등록되지 않았습니다.");
        }

        public object Resolve(Type type)
        {
            if (_singletons.TryGetValue(type, out var singleton))
                return singleton;

            if (_transients.TryGetValue(type, out var factory))
                return factory();

            throw new InvalidOperationException($"{type.Name}이(가) 등록되지 않았습니다.");
        }
    }
}