using Parkwhere05.DAL;
using Parkwhere05.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace Parkwhere05.Services
{
    public class WeatherGateway : DataGateway<Weather>, IWeatherGateway
    {
        static String KEY_WEATHERFORECAST = "weatherForecast"; // parent node
        static String KEY_AREA = "area";
        static String KEY_NAME = "name";
        static String KEY_FORECAST = "forecast";
        static String KEY_LAT = "lat";
        static String KEY_LON = "lon";
        static String KEY_ZONE = "zone";

        public void DeleteWeatherDataFromDB()
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE weather");
        }

        public void GetWeatherAndUpdateDB()
        {
            string dataset = "nowcast";
            string keyref = "781CF461BB6606AD4AF8F309C0CCE994AC81FD9664F88220";         // Developer Key to use API

            // URL Connection to NEA Dataset API
            String url = "http://www.nea.gov.sg/api/WebAPI?dataset=" + dataset + "&keyref=" + keyref;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());

                XmlNodeList nodeList = xmlDoc.GetElementsByTagName(KEY_WEATHERFORECAST);

                XmlNode xmlNode = nodeList.Item(0);

                XmlElement firstElement = (XmlElement) xmlNode;
                XmlNodeList nameList = firstElement.GetElementsByTagName(KEY_AREA);

                for (int i=0; i<nameList.Count; i++)
                {
                    XmlElement nameElement = (XmlElement)nameList.Item(i);

                    String keyName = nameElement.GetAttribute(KEY_NAME);
                    String keyForecast = nameElement.GetAttribute(KEY_FORECAST);
                    String keyZone = nameElement.GetAttribute(KEY_ZONE);
                    String keyLat = nameElement.GetAttribute(KEY_LAT);
                    String keyLon = nameElement.GetAttribute(KEY_LON);

                    //System.Diagnostics.Debug.WriteLine("keyName: "+ keyName+ " keyForecast: "+ keyForecast);
                    db.Database.ExecuteSqlCommand("INSERT INTO weather (areaName, forecast, zone, lat, lon) VALUES ('" + keyName + "', '" + keyForecast + "', '" + keyZone + "', " + keyLat + ", " + keyLon + ")");

                }


                
            }
            catch (WebException we)
            {
                //Run code if failed to retrieve weather forecast
                //weatherForecast = "My current location: " + location + ". Error accessing NEA API. Forecast cannot be retrived.";
            }

            
        }

        public List<Weather> GetWeatherFromDB()
        {
            List<Weather> weatherListFromDb = new List<Weather>();
            weatherListFromDb = data.SqlQuery("SELECT * FROM weather").ToList();

            List<Weather> weatherList = new List<Weather>();

            for (int i=0; i< weatherListFromDb.Count; i++)
            {
                Weather weatherObj = new Weather();
                weatherObj.areaName = weatherListFromDb[i].areaName;
                weatherObj.forecast = weatherListFromDb[i].forecast;
                weatherObj.zone = weatherListFromDb[i].zone;
                weatherObj.lat = weatherListFromDb[i].lat;
                weatherObj.lon = weatherListFromDb[i].lon;

                weatherList.Add(weatherObj);

            }

            return weatherList;
        }

        public string GetCurrentWeather(List<Weather> weatherList, string location)
        {
            //string weatherForecast = "";
            //string dataset = "nowcast";
            //string keyref = "781CF461BB6606AD4AF8F309C0CCE994AC81FD9664F88220";         // Developer Key to use API

            //// URL Connection to NEA Dataset API
            //String url = "http://www.nea.gov.sg/api/WebAPI?dataset=" + dataset + "&keyref=" + keyref;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //try
            //{
            //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //    Stream receiveStream = response.GetResponseStream();
            //    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            //    string content;
            //    using (readStream)
            //    {
            //        content = readStream.ReadLine();
            //    }

            //    string[] tokens = content.Split(new[] { '<' + "area name=" + '"', '"' + " forecast=" + '"', '"' + " icon=" + '"' }, StringSplitOptions.None);
            //    string myArea = location.ToString();
            //    int i = 0;
            //    while (!tokens[i].Equals(myArea.ToUpper()))
            //    {
            //        i++;
            //    }
            //    weatherForecast = "My current location: " + tokens[i] + " | Forecast: " + tokens[i + 1];
            //}
            //catch (WebException we)
            //{
            //    //Run code if failed to retrieve weather forecast
            //    weatherForecast = "My current location: " + location + ". Error accessing NEA API. Forecast cannot be retrived.";
            //}

            string weatherForecast = "";
            weatherForecast = "My current location: " + location + ". Error accessing NEA API. Forecast cannot be retrived.";

            for (int i=0; i<weatherList.Count; i++)
            {
                if (weatherList[i].areaName.Equals(location.ToUpper()))
                {
                    return weatherForecast = "My current location: " + location + " | Forecast: " + weatherList[i].forecast;
                }
            }
            
            return weatherForecast;
        }
    }
}