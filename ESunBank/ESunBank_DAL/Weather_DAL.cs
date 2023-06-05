using ESunBank.Models;
using ESunBank_DAL.Interface;

namespace ESunBank_DAL
{
    public class Weather_DAL : IWeather_DAL
    {
        private readonly HttpClient _httpClient;

        public Weather_DAL(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetWeather()
        {
            // 透過OpenData API取得宜蘭縣某一時間區間的天氣預報
            HttpResponseMessage response = await _httpClient.GetAsync("https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-C0032-001?Authorization=CWB-4C0843C2-7B83-4E9A-A4C8-485192A2063C&limit=1&locationName=%E5%AE%9C%E8%98%AD%E7%B8%A3&elementName=Wx");

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}