
using ESun_BLL.Models;
using ESun_DAL.Repository.Models;
using ESunBank.Models;
using ESunBank_BLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Globalization;

namespace ESun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        
        private readonly IWeather_BLL _weather_BLL;

        public WeatherController(IWeather_BLL weather_BLL)
        {
            _weather_BLL = weather_BLL;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<CityFutureWeather>> GetWeather()
        {
            return Ok(await _weather_BLL.GetWeather());
        }
    }
}
