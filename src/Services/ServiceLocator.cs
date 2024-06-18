using System;
using System.Collections.Generic;

namespace AnimeVoices.Services
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<string, Func<object>> _namedServices = new Dictionary<string, Func<object>>();
        private static readonly Dictionary<Type, Func<object>> _services = new Dictionary<Type, Func<object>>();

        public static void Register<T>(Func<T> resolver, string name = null) where T : class
        {
            if (string.IsNullOrEmpty(name))
            {
                _services[typeof(T)] = () => resolver();
            }
            else
            {
                _namedServices[name] = () => resolver();
            }
        }

        public static T Resolve<T>(string name = null) where T : class
        {
            if (string.IsNullOrEmpty(name))
            {
                if (_services.TryGetValue(typeof(T), out var resolver))
                {
                    return resolver() as T;
                }
            }
            else
            {
                if (_namedServices.TryGetValue(name, out var resolver))
                {
                    return resolver() as T;
                }
            }

            throw new KeyNotFoundException($"Service of type {typeof(T)} with name {name} is not registered.");
        }
    }
}
