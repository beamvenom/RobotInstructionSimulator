using System.Net;
using System.Runtime.Caching;

namespace RobotInstructionSimulator.CachedFactory
{
    public abstract class CachedFactory<T> : ICachedFactory<T>
    {
        private static MemoryCache FactoryCache { get; } = new($"FactoryCache_{typeof(T).Name}");
        public T Create(string type)
        {
            //For example for bigger projects if below would be something time/money costly and we only need one. Which is why we are caching it.
            if (FactoryCache[type] is T instance)
                return instance;

            T newInstance = CreateInstance(type) ?? throw new Exception();
            Console.WriteLine(newInstance.GetType().ToString());

            FactoryCache.Set(newInstance.GetType().ToString(), newInstance, DateTimeOffset.Now.AddMinutes(10));

            return newInstance;
        }
        public void ClearCache()
        {
            FactoryCache.Dispose();
        }
        protected abstract T CreateInstance(string type);
        
    }

}
