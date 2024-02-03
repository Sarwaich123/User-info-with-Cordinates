using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MappingSolutionFinal.Models
{
    public partial class Output
    {
        [Key]
        public string Role { get; set; }
    }
}
