using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESun_BLL.Models
{
    public class CityFutureWeather
    {
        public string City { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Weather { get; set; } = null!;

        public DateTime CreateTime { get; set; }
    }
}
