using System;
using System.Runtime.Caching;

namespace Tekhub.Infrastructure.Caching
{
    public class CacheHelper : ICacheProvider
    {
        private readonly double secondsIn60Days = 60 * 24 * 60 * 60.0;
        private readonly ObjectCache _cache;

        public CacheHelper()
        {
            _cache = MemoryCache.Default;
        }

        public void Put<T>(string cacheItemName, T objectToCache)
        {
            Put<T>(cacheItemName, objectToCache, secondsIn60Days);
        }

        public void Put<T>(string cacheItemName, T objectToCache, double expirationSeconds)
        {
            _cache.Set(cacheItemName, objectToCache, new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(expirationSeconds)
            });
        }

        public T Get<T>(string cacheItemName)
        {
            var cachedItem = _cache[cacheItemName];
            if (cachedItem == null)
            {
                return default(T);
            }

            return (T) cachedItem;
        }

        public void Remove<T>(string cacheItemName)
        {
            _cache.Remove(cacheItemName);
        }
    }
}
