using System;
using System.Collections.Generic;

namespace NotVineApp.Common.Services
{
    public class ServiceLocator
    {
        private static ServiceLocator? _instance;
        public static ServiceLocator Instance => _instance ??= new ServiceLocator();

        private readonly Dictionary<Type, Func<object>> _factories = new();
        private readonly Dictionary<Type, object> _singletons = new();

        private ServiceLocator() { }

        public void RegisterTransient<TService>(Func<TService> factory) where TService : class
        {
            _factories[typeof(TService)] = () => factory();
        }

        public void RegisterSingleton<TService>(TService instance) where TService : class
        {
            _singletons[typeof(TService)] = instance;
        }

        public void RegisterSingleton<TService>(Func<TService> factory) where TService : class
        {
            var instance = factory();
            _singletons[typeof(TService)] = instance;
        }

        public TService Resolve<TService>() where TService : class
        {
            var type = typeof(TService);

            if (_singletons.TryGetValue(type, out var singleton))
                return (TService)singleton;

            if (_factories.TryGetValue(type, out var factory))
                return (TService)factory();

            throw new InvalidOperationException($"{type.Name}이(가) 등록되지 않았습니다.");
        }

        public object Resolve(Type type)
        {
            if (_singletons.TryGetValue(type, out var singleton))
                return singleton;

            if (_factories.TryGetValue(type, out var factory))
                return factory();

            throw new InvalidOperationException($"{type.Name}이(가) 등록되지 않았습니다.");
        }
    }
}