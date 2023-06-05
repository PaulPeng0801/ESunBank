using ESunBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESunBank_DAL.Interface
{
    public interface IWeather_DAL
    {
        Task<string> GetWeather();
    }
}
