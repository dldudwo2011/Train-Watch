using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrainWatch.Entities
{
    public class RollingStock
    {
        [Key]
        public string ReportingMark { get; set; }
        public string Owner { get; set; }
        public int LightWeight { get; set; }
        public int LoadLimit { get; set; }
        public int Capacity { get; set; }
        public int? RailCarTypeID { get; set; }
        public int? YearBuilt { get; set; }
        public bool InService { get; set; }
        public string Notes { get; set; }
    }
}
