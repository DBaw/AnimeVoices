using System;
using System.Collections.Generic;

namespace AnimeVoices.Services
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, Func<object>> _services = new Dictionary<Type, Func<object>>();

        public static void Register<T>(Func<T> resolver) where T : class
        {
            _services[typeof(T)] = () => resolver();
        }

        public static T Resolve<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out var resolver))
            {
                return resolver() as T;
            }
            else
            {
                throw new KeyNotFoundException($"Service of type {typeof(T)} is not registered.");
            }
        }
    }
}
