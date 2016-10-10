using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parkwhere05.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ParkingHistory
    {
        [Display(Name = "Parking History ID")]
        [Key]
        public int parkingHistoryId { get; set; }

        [Display(Name = "Carpark ID")]
        public Nullable<int> carparkId { get; set; }

        [Display(Name = "Username")]
        public string username { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> date { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        public virtual Carpark Carpark { get; set; }
    }
}