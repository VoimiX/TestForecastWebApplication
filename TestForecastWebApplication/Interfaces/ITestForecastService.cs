using System.Threading.Tasks;
using TestForecast.WebApplication.DTO;

namespace TestForecast.WebApplication.Interfaces
{
    public interface ITestForecastService
    {
        Task<ForecastResult> GetForecastAsync(ForecastRequest request);
    }
}
