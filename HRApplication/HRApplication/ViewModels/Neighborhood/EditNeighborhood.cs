using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRApplication.ViewModels.Neighborhood
{
    public class EditNeighborhood
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GovernorateId { get; set; }
        public SelectList Governorates { get; set; }
        public string Message { get; set; }
    }
}