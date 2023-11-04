using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestForecast.WebApplication.DTO
{
    public class ForecastItem
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int Stock { get; set; }
    }
}
