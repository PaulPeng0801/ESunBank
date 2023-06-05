using ESun_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESunBank_BLL.Interface
{
    public interface IWeather_BLL
    {
        Task<CityFutureWeather> GetWeather();
    }
}
