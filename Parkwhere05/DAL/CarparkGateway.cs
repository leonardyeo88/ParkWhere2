using System.Collections.Generic;
using System.Linq;
using Parkwhere05.Models;

using System.IO; //to be removed
using System;
using System.Globalization;

namespace Parkwhere05.DAL
{
    public class CarparkGateway : DataGateway<Carpark>
    {
        IEnumerable<Carpark> Carparks;

        public CarparkGateway()
        {
            this.data = db.Set<Carpark>();

            //var reader = new StreamReader(File.OpenRead(@"C:\Users\Leonard\Desktop\3102\hdb-carpark-information\hdb-carpark-information.csv"));

            //int count = 0;

            //while (!reader.EndOfStream)
            //{
            //    var line = reader.ReadLine();
            //    var values = line.Split(',');

            //    if (count > 457 && values[0] != string.Empty && values[1] != string.Empty && values[2] != string.Empty && values[3] != string.Empty && values[4] != string.Empty && values[5] != string.Empty && values[6] != string.Empty && values[7] != string.Empty && values[8] != string.Empty && values[9] != string.Empty)
            //    {
            //        try
            //        {
            //            db.Database.ExecuteSqlCommand("INSERT INTO carpark (carparkNo, address, x_coord, y_coord, carparkType, typeOfparking, shortTermparking, freeParking, nightParking, parkAndrideScheme, adhocParking) VALUES ('" + values[0].Replace("\"", string.Empty).Trim() + "', '" + values[1].Replace("\"", string.Empty).Trim() + "', " + values[2].Replace("\"", string.Empty).Trim() + ", " + values[3].Replace("\"", string.Empty).Trim() + ", '" + values[4].Replace("\"", string.Empty).Trim() + "', '" + values[5].Replace("\"", string.Empty).Trim() + "','" + values[6].Replace("\"", string.Empty).Trim() + "', '" + values[7].Replace("\"", string.Empty).Trim() + "', '" + values[8].Replace("\"", string.Empty).Trim() + "','" + values[9].Replace("\"", string.Empty).Trim() + "', '')");
            //        }
            //        catch (Exception ex)
            //        {

            //        }
                    
            //    }
            //    count++;
            //}

            

        }

        public List<string[]> GetAllCarparks()
        {
            List<string[]> CarparkList;

            Carparks = SelectAll();
            CarparkList = new List<string[]>();

            foreach (var item in Carparks)
            {
                string[] listString = new string[7];
                listString[0] = item.id.ToString();
                listString[1] = item.carparkNo;
                listString[2] = item.address;
                listString[3] = item.carparkType;
                listString[4] = item.typeOfparking;
                listString[5] = item.x_coord.ToString();
                listString[6] = item.y_coord.ToString();
                CarparkList.Add(listString);
            }
            return CarparkList;
        }

        public List<string[]> searchCarpark(string address)
        {
            if (address== null)
            {
                List<string[]> CarparkList;

                Carparks = data.SqlQuery("SELECT * From carpark ").ToList();
                CarparkList = new List<string[]>();

                foreach (var item in Carparks)
                {
                    string[] listString = new string[7];
                    listString[0] = item.id.ToString();
                    listString[1] = item.carparkNo;
                    listString[2] = item.address;
                    listString[3] = item.carparkType;
                    listString[4] = item.typeOfparking;
                    listString[5] = item.x_coord.ToString();
                    listString[6] = item.y_coord.ToString();
                    CarparkList.Add(listString);
                }
                return CarparkList;
               
            }
            else
            {
                string str = address.Substring(0, 5);
               
                List<string[]> CarparkList;

                Carparks = data.SqlQuery("SELECT * From carpark WHERE address LIKE '%" + str + "%'").ToList();
                CarparkList = new List<string[]>();

                foreach (var item in Carparks)
                {
                    string[] listString = new string[7];
                    listString[0] = item.id.ToString();
                    listString[1] = item.carparkNo;
                    listString[2] = item.address;
                    listString[3] = item.carparkType;
                    listString[4] = item.typeOfparking;
                    listString[5] = item.x_coord.ToString();
                    listString[6] = item.y_coord.ToString();
                    CarparkList.Add(listString);
                }
                return CarparkList;

            }
        }
        public List<string[]> FilterAddressByType(string address,string parkingTyperesult, string carparkTyperesult)
        {
            
                string resultAddress = address.Substring(0, 5);
             
            List<string[]> CarparkList;

            Carparks = data.SqlQuery("SELECT * From carpark WHERE address LIKE '%" + resultAddress + "%' AND typeOfparking = '" + parkingTyperesult + "' AND carparkType = '" + carparkTyperesult + "'").ToList();
            CarparkList = new List<string[]>();

            foreach (var item in Carparks)
            {
                string[] listString = new string[7];
                listString[0] = item.id.ToString();
                listString[1] = item.carparkNo;
                listString[2] = item.address;
                listString[3] = item.carparkType;
                listString[4] = item.typeOfparking;
                listString[5] = item.x_coord.ToString();
                listString[6] = item.y_coord.ToString();
                CarparkList.Add(listString);
            }
            return CarparkList;

        }
        public List<string[]> FilterByType(string parkingTyperesult, string carparkTyperesult)
        {

            
            List<string[]> CarparkList;

            Carparks = data.SqlQuery("SELECT * From carpark WHERE typeOfparking = '" + parkingTyperesult + "' AND carparkType = '" + carparkTyperesult + "'").ToList();
            CarparkList = new List<string[]>();

            foreach (var item in Carparks)
            {
                string[] listString = new string[7];
                listString[0] = item.id.ToString();
                listString[1] = item.carparkNo;
                listString[2] = item.address;
                listString[3] = item.carparkType;
                listString[4] = item.typeOfparking;
                listString[5] = item.x_coord.ToString();
                listString[6] = item.y_coord.ToString();
                CarparkList.Add(listString);
            }
            return CarparkList;

        }

        public IEnumerable<Carpark> GetTopFiveBookmarks()
        {
            //Carparks = data.SqlQuery("SELECT * FROM dbo.Carparks C WHERE ( C.id IN ("
            //    + "SELECT TOP(5) B.carparkId FROM dbo.Bookmarks B GROUP BY B.carparkId ORDER BY COUNT(*) DESC)"
            //    + ")").ToList();


            /* To Insert BookMarks*/
            //int noOfCarParkReccrds = 2114;
            //int noOfUserRecords = 48171;
            //for (int i = 0; i < 1000; i++)
            //{
            //    Random r = new Random();
            //    int rCarParkRecords = r.Next(1, noOfCarParkReccrds + 1);
            //    int rUserRecords = r.Next(1, noOfUserRecords + 1);

            //    DateTime date = DateTime.UtcNow.AddDays(new Random().Next(90));

            //    db.Database.ExecuteSqlCommand("INSERT INTO bookmark (carparkId, User_UserId, date) VALUES (" + rCarParkRecords + ", " + rUserRecords + ", '" + date.Date.ToString("yyyy-MM-dd") + "')");
            //}

            /* To Insert User*/
            //for (int i=0; i<100000; i++)
            //{
            //    db.Database.ExecuteSqlCommand("INSERT INTO user (User_email, User_password) VALUES ('email" + i + "@email.com', 'password" + i + "')");
            //}


            Carparks = data.SqlQuery("SELECT * FROM carpark C, bookmark B WHERE C.id = B.carparkId GROUP BY B.carparkId ORDER BY COUNT(*) DESC LIMIT 5 ").ToList();
            return Carparks;
        }
    }
}