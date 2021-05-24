using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRApplication.Models
{
    public class Neighborhood
    {
        [Key]
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        [ForeignKey("Governorate")]
        public int GovernorateId { get; set; }

        //navigation property
        public virtual Governorate Governorate { get; set; }
    }
}