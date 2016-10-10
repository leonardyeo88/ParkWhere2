using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parkwhere05.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bookmark
	{

        [Display(Name = "Bookmark ID")]
        [Key]
        public int BookmarkId { get; set; }

        [Display(Name = "Carpark ID")]
        public Nullable<int> carparkId { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> date { get; set; }

        //[Display(Name = "Username")]
        //public string username { get; set; }

        public virtual Carpark Carpark { get; set; }
    }
}