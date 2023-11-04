using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestForecast.WebApplication.Filters
{
    public class SortByParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            if (parameter.Name.Equals("OrderBy", StringComparison.InvariantCultureIgnoreCase))
            {
                parameter.Schema.Enum = new[] { "title", "price", "stock" }.Select(p => new OpenApiString(p)).ToList<IOpenApiAny>();
            }
        }
    }
}
