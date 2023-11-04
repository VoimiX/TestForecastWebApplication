using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using AutoMapper;
using TestForecast.WebApplication;
using System.Net.Http.Headers;
using System.Text;
using TestForecast.WebApplication.Filters;
using TestForecast.WebApplication.Interfaces;
using TestForecast.WebApplication.Services;

namespace TestForecastWebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMemoryCache();

            string url = Configuration.GetValue<string>("ExternalApiHost");
            string user = Configuration.GetValue<string>("ExternalApiLogin");
            string password = Configuration.GetValue<string>("ExternalApiPassword");

            var authorization =
                new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                        Encoding.ASCII.GetBytes(
                           $"{user}:{password}")));

            services
                .AddRefitClient<IExternalForecastService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(url))
                .ConfigureHttpClient(c => c.DefaultRequestHeaders.Authorization = authorization);

            services.AddSwaggerGen(c =>
            {
                c.ParameterFilter<SortByParameterFilter>();
                c.UseInlineDefinitionsForEnums();
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<ITestForecastService, TestForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // This middleware serves generated Swagger document as a JSON endpoint
            app.UseSwagger();

            // This middleware serves the Swagger documentation UI
            app.UseSwaggerUI(c =>
            { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Forecast API V1");
            });
        }
    }
}
