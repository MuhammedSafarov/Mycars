using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mycars.Dtos
{
    public class FeatureUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Region { get; set; }

        [Required]
        public string Colour { get; set; }

        [Required]
        public int AZN { get; set; }
    }
}
