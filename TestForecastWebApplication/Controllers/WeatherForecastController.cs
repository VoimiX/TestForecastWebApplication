using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Refit;
using TestForecast.WebApplication.DTO;
using TestForecast.WebApplication.Interfaces;
using ForecastRequest = TestForecast.WebApplication.Request.ForecastRequest;

namespace TestForecast.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITestForecastService _testForecastService;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITestForecastService testForecastService, IMapper mapper)
        {
            _logger = logger;
            _testForecastService = testForecastService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ForecastResult> Get([FromQuery] ForecastRequest request)
        {
            var serviceRequest = _mapper.Map<DTO.ForecastRequest>(request);

            return await _testForecastService.GetForecastAsync(serviceRequest);
        }
    }
}
