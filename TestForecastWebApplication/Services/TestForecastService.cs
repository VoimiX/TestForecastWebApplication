using Microsoft.Extensions.Caching.Memory;
using Refit;
using System;
using System.Threading.Tasks;
using TestForecast.WebApplication.DTO;
using TestForecast.WebApplication.Interfaces;

namespace TestForecast.WebApplication.Services
{
    public class TestForecastService : ITestForecastService
    {
        private IExternalForecastService _externalForecastService;
        private IMemoryCache _memoryCache;
        public TestForecastService(IExternalForecastService externalForecastService, IMemoryCache memoryCache)
        {
            _externalForecastService = externalForecastService;
            _memoryCache = memoryCache;
        }

        public async Task<ForecastResult> GetForecastAsync(ForecastRequest request)
        {
            ForecastResult serviceResult;
            try
            {
                serviceResult = await _externalForecastService.GetAsync(request);
                _memoryCache.Set(request.ToString(), serviceResult, new MemoryCacheEntryOptions()
                { SlidingExpiration = TimeSpan.FromSeconds(30) });
                serviceResult.IsDataFresh = true;
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    if (_memoryCache.TryGetValue(request.ToString(), out ForecastResult cachedForecastResult))
                    {
                        cachedForecastResult.IsDataFresh = false;
                        return cachedForecastResult;
                    }
                    throw;
                }
                throw;
            }

            return serviceResult;
        }
    }
}
