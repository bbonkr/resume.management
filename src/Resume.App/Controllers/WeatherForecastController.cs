using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kr.bbon.AspNetCore;
using kr.bbon.AspNetCore.Models;
using kr.bbon.AspNetCore.Mvc;
using kr.bbon.Core;
using kr.bbon.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resume.App.Infrastructure.Mvc;

namespace Resume.App.Controllers
{
    [ApiController]
    [Area(DefaultValues.AreaName)]
    [Route(DefaultValues.RouteTemplate)]
    [ApiVersion(DefaultValues.ApiVersion)]
    [Authorize]
    [Produces(PRODUCE_MIMETYPE)]
    public class WeatherForecastController : ApiContractBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        public WeatherForecastController( ILogger<WeatherForecastController> logger)
            : base(logger)
        {

        }

        /// <summary>
        /// Get data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>),StatusCodes.Status200OK )]
        [ProducesErrorResponseType(typeof(ApiResponseModel<ErrorModel>))]
        public IEnumerable<WeatherForecast> Get([FromQuery]int  page = 1)
        {
            if (page < 1)
            {
                // throw new ArgumentException("Page must be bigger than 0");
                throw new ApiException(StatusCodes.Status400BadRequest, "Page must be bigger than 0");
            }
            
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
