using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parkwhere05.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Carpark
	{
        public Carpark()
        {
            this.Bookmarks = new HashSet<Bookmark>();
            this.ParkingHistories = new HashSet<ParkingHistory>();
        }

        [Display(Name = "ID")]
        [Key]
        public int id { get; set; }

        [Display(Name = "Carpark Code")]
        public string carparkNo { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Latitude")]
        public double x_coord { get; set; }

        [Display(Name = "Longitude")]
        public double y_coord { get; set; }

        [Display(Name = "Type of Carpark")]
        public string carparkType { get; set; }

        [Display(Name = "Type of Parking")]
        public string typeOfparking { get; set; }

        [Display(Name = "Short Term Parking")]
        public string shortTermparking { get; set; }

        [Display(Name = "Free Parking")]
        public string freeParking { get; set; }

        [Display(Name = "Night Parking")]
        public string nightParking { get; set; }

        [Display(Name = "Park&Ride Scheme")]
        public string parkAndrideScheme { get; set; }

        [Display(Name = "Adhoc Parking")]
        public string adhocParking { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<ParkingHistory> ParkingHistories { get; set; }
    }
}