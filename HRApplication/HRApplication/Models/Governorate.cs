using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRApplication.Models
{
    public class Governorate
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        //navigation property
        public virtual List<Neighborhood> Neighborhoods { get; set; }
    }
}