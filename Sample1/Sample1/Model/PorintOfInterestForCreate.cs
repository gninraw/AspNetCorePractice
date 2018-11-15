using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample1.Model
{
    public class PorintOfInterestForCreate
    {
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
