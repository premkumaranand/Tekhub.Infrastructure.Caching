namespace Tekhub.Infrastructure.Caching
{
    public interface ICacheProvider
    {
        void Put<T>(string cacheItemName, T objectToCache);
        void Put<T>(string cacheItemName, T objectToCache, double expirationSeconds);
        T Get<T>(string cacheItemName);
        void Remove<T>(string cacheItemName);
    }
}
