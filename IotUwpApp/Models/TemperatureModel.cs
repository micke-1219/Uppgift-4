using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotUwpApp.Models
{
    public class TemperatureModel
    {
        public double Temperature;
        public double Humidity;

        public TemperatureModel(double aTemperature, double aHumidity)
        {
            Temperature = aTemperature;
            Humidity = aHumidity;
        }
    }
}
