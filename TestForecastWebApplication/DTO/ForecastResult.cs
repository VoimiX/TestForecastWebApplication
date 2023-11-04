namespace TestForecast.WebApplication.DTO
{
    public class ForecastResult
    {
        public ForecastInnerResult Result { get; set; }
        public bool IsDataFresh { get; set; }
    }
}
