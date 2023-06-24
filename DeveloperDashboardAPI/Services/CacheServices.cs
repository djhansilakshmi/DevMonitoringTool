using System.Runtime.Caching;

namespace DeveloperDashboardAPI.Services
{
    public class CacheServices
    {
        private static readonly ObjectCache cache = MemoryCache.Default;
        private static readonly TimeSpan cacheDuration = TimeSpan.FromMinutes(10);

        public static async Task<T> GetCachedResponse<T>(string cacheKey, Func<Task<T>> fetchResponse)
        {
            if (cache.Contains(cacheKey))
            {
                return (T)cache.Get(cacheKey);
            }

            T response = await fetchResponse.Invoke();

            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.Add(cacheDuration)
            };

            cache.Set(cacheKey, response, policy);

            return response;
        }
    }
}
