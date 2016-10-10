using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parkwhere05.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PetrolStation
    {
        [Display(Name = "ID")]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Station Name")]
        public string petrolStationName { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Latitude")]
        public Nullable<double> latitude { get; set; }

        [Display(Name = "Longitude")]
        public Nullable<double> longitude { get; set; }
    }
}