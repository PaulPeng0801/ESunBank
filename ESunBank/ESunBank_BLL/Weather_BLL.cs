using ESun_BLL.Models;
using ESun_DAL.Repository.Models;
using ESunBank.Models;
using ESunBank_BLL.Interface;
using ESunBank_DAL.Interface;
using Newtonsoft.Json;
using System.Globalization;

namespace ESunBank_BLL
{
    public class Weather_BLL : IWeather_BLL
    {
        private readonly IWeather_DAL _weather_DAL;
        private readonly WeatherContext _db;
        public Weather_BLL(IWeather_DAL weather_DAL, WeatherContext db)
        {
            _weather_DAL = weather_DAL;
            _db = db;
        }

        public async Task<CityFutureWeather> GetWeather()
        {
            // 時間格式
            string format = "yyyy-MM-dd HH:mm:ss";

            // 從資料層(DAL)獲取的Data
            var cityFutureWeather = await _weather_DAL.GetWeather();

            // Json轉物件
            FutureWeatherModel obj = JsonConvert.DeserializeObject<FutureWeatherModel>(cityFutureWeather);

            // 顯示&儲存進DB的Model
            CityFutureWeather cityWeather = new();

            // 抽絲剝繭取得所需的資料
            WeatherRecords records = JsonConvert.DeserializeObject<WeatherRecords>((obj.records).ToString());
            List<WeatherLocation> location = JsonConvert.DeserializeObject<List<WeatherLocation>>((records.location).ToString());
            List<WeatherElement> elements = JsonConvert.DeserializeObject<List<WeatherElement>>((location[0].weatherElement).ToString());
            List<WeatherTime> time = JsonConvert.DeserializeObject<List<WeatherTime>>((elements[0].time).ToString());
            WeatherDetail detail = JsonConvert.DeserializeObject<WeatherDetail>((time[0].parameter).ToString());

            // 資料塞進Model
            cityWeather.City = location[0].locationName;
            cityWeather.StartTime = DateTime.ParseExact(time[0].startTime, format, CultureInfo.CurrentCulture);
            cityWeather.EndTime = DateTime.ParseExact(time[0].endTime, format, CultureInfo.CurrentCulture);
            cityWeather.Weather = detail.parameterName;
            cityWeather.CreateTime = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), format, CultureInfo.CurrentCulture);

            // 將資料塞進Db
            FutureWeather db = new()
            {
                City = cityWeather.City,
                StartTime = cityWeather.StartTime,
                EndTime = cityWeather.EndTime,
                Weather = cityWeather.Weather,
                CreateTime = cityWeather.CreateTime
            };
            _db.FutureWeathers.Add(db);
            _db.SaveChanges();
            return cityWeather;
        }
    }
}