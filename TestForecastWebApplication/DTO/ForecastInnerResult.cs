using System;
using System.Collections.Generic;
using System.Text;

namespace TestForecast.WebApplication.DTO
{
    public class ForecastInnerResult
    {
        public int TotalItems { get; set; }
        public ForecastItem[] Items { get; set; }
    }
}
