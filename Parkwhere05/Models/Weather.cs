using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parkwhere05.Models
{
    public class Weather
    {
        [Key]
        public int weatherId { get; set; }

        public String areaName { get; set; }

        public String forecast { get; set; }

        public String zone { get; set; }

        public Decimal lat { get; set; }

        public Decimal lon { get; set; }
    }
}