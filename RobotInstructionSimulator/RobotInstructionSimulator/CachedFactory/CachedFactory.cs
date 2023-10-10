using System.Net;
using System.Runtime.Caching;

namespace RobotInstructionSimulator.CachedFactory
{
    public abstract class CachedFactory<T> : ICachedFactory<T>
    {
        private static MemoryCache FactoryCache { get; set; } = new("FactoryCahe");
        public virtual async Task<T> CreateAsync(string type)
        {
            //For example for bigger projects if below would be something time/money costly and we only need one. Which is why we are caching it.
            if (FactoryCache[type.ToLower()] is T instance)
                return instance;

            T newInstance = await CreateInstanceAsync(type) ?? throw new Exception();

            FactoryCache.Set(newInstance.GetType().ToString().ToLower(), newInstance, DateTimeOffset.Now.AddMinutes(10));

            return newInstance;
        }
        public static void ClearCache()
        {
            FactoryCache = new("FactoryCahe");
        }
        protected abstract Task<T> CreateInstanceAsync(string type);
        
    }

}
