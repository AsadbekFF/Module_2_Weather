using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module_2_Weather.Models
{
    public class WeatherContent
    {
        public string Name { get; set; }
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
    }
    
    public class Weather
    {
        public string Description { get; set; }
    }
}
