namespace TestForecast.WebApplication.DTO
{
    public class ForecastRequest
    {
        public string Filter { get; set; }
        public string OrderBy { get; set; }
        public string OrderDirection { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; } 
        public string Expand { get; set; }
        public override string ToString()
        {
            return $"filter={Filter}, OrderBy={OrderBy}, OrderDirection={OrderDirection}, Skip={Skip}, Take={Take}, Expand={Expand}";
        }
    }
}
