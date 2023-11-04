using Refit;
using System.Threading.Tasks;
using TestForecast.WebApplication.DTO;

namespace TestForecast.WebApplication.Interfaces
{
    public interface IExternalForecastService
    {
        [Get("/v1/Stock")]
        Task<ForecastResult> GetAsync(ForecastRequest request);
    }
}
