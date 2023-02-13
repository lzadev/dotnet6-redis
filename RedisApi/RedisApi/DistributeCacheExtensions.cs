using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace RedisApi
{
    public static class DistributeCacheExtensions
    {
        public static async Task SetCacheAsync<T>(
            this IDistributedCache cache,
            string key,
            T data, TimeSpan absoluteExpirationTime,
            TimeSpan? unUsedTimeExpiration = null)
        {

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = absoluteExpirationTime,
                SlidingExpiration = unUsedTimeExpiration
            };

            var dataToCacheAsString = JsonSerializer.Serialize(data);
            var dataToCacheAsBytes = Encoding.UTF8.GetBytes(dataToCacheAsString);
            await cache.SetAsync(key, dataToCacheAsBytes, options);
        }

        public static void SetCacheSync<T>(
                this IDistributedCache cache,
                string key,
                T data, TimeSpan absoluteExpirationTime,
                TimeSpan? unUsedTimeExpiration = null)
        {

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = absoluteExpirationTime,
                SlidingExpiration = unUsedTimeExpiration
            };

            var dataToCacheAsString = JsonSerializer.Serialize(data);
            var dataToCacheAsBytes = Encoding.UTF8.GetBytes(dataToCacheAsString);
            cache.Set(key, dataToCacheAsBytes, options);
        }

        public static async Task<T> GetCacheAsync<T>(
                this IDistributedCache cache,
                string key)
        {
            var dataCachedAsBytes = await cache.GetAsync(key);

            if (dataCachedAsBytes is null) return default!;

            var dataCachedAsString = Encoding.UTF8.GetString(dataCachedAsBytes);

            var result = JsonSerializer.Deserialize<T>(dataCachedAsString);
            return result!;
        }
    }
}
