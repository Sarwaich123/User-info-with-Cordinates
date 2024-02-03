using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MappingSolutionFinal.Models
{
    public partial class Getuser
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public string Station_City { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
