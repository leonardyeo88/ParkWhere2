using Parkwhere05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkwhere05.Services
{
    interface IWeatherGateway
    {
        string GetCurrentWeather(List<Weather> weatherList, string location);
    }
}
