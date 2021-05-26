using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace COVID19.Client.Services
{
    public class ServiceLocator : IServiceLocator
    {
        /// <summary>
        /// Static instance for service locator
        /// </summary>
        public static ServiceLocator Instance { get; set; } = new ServiceLocator();
        /// <summary>
        /// This w illhold the mapping for the type and its service implementation
        /// </summary>
        private readonly ConcurrentDictionary<Type, object> _serviceMapping = new ConcurrentDictionary<Type, object>();
        /// <summary>
        /// This will get the implementation of registered T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() where T : class
        {
            _serviceMapping.TryGetValue(typeof(T), out object targetService);
            return targetService as T;
        }
        /// <summary>
        /// This registers the implementation of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        /// <param name="replace"></param>
        public void Register<T>(T service, bool replace = true)
        {
            if (replace)
                _serviceMapping.TryRemove(typeof(T), out object removedService);

            _serviceMapping.TryAdd(typeof(T), service);
        }
        /// <summary>
        /// Unregisters the T service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void UnRegister<T>()
        {
            _serviceMapping.TryRemove(typeof(T), out object service);
        }
    }
}
