using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESun_DAL.Repository.Models
{

    public class FutureWeatherModel
    {

        public bool success { get; set; } 

        public object result { get; set; } = null!;
        public object records { get; set; } = null!;
    }
    public class WeatherRecords
    {

        public string datasetDescription { get; set; } = null!;

        public object location { get; set; } = null!;
    }

    public class WeatherLocation
    {
        public string locationName { get; set; } = null!;

        public object weatherElement { get; set; } = null!;
    }

    public class WeatherElement
    {
        public string elementName { get; set; } = null!;

        public object time { get; set; } = null!;
    }

    public class WeatherTime
    {
        public string startTime { get; set; } = null!;

        public string endTime { get; set; } = null!;

        public object parameter { get; set; } = null!;
    }

    public class WeatherDetail
    {
        public string parameterName { get; set; } = null!;

        public string parameterValue { get; set; } = null!;
    }
}
