using System;
using System.Collections.Generic;

namespace SeminarMvvmApp.Utils
{
    public class IocContainer
    {
        private readonly Dictionary<Type, Func<object>> _registrations = new();

        public void Register<TService>(Func<TService> factory) where TService : class
        {
            _registrations[typeof(TService)] = () => factory();
        }
        public TService Resolve<TService>() where TService : class
        {
            if (_registrations.TryGetValue(typeof(TService), out var factory))
                return (TService)factory();
            throw new InvalidOperationException($"{typeof(TService)} not registered");
        }
    }
}
