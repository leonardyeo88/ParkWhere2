using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parkwhere05.Models
{
    public class BookmarkReport
    {
        [Key]
        public int BookmarkId { get; set; }
        public int carparkId { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string carparkNo { get; set; }
        public string address { get; set; }
        public decimal x_coord { get; set; }
        public decimal y_coord { get; set; }
        public int UserCount { get; set; }
    }
}