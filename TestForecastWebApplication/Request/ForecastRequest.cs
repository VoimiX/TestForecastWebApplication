using TestForecast.WebApplication.Enums;

namespace TestForecast.WebApplication.Request
{
    public class ForecastRequest
    {
        public string Filter { get; set; }
        public string OrderBy { get; set; }
        public OrderDirectionEnum OrderDirection { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; } = 10;
        public string Expand { get; set; }

    }
}
