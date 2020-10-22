using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace Mycars.Dtos
{
    public class BrandCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string brand { get; set; }
        
        [Required]
        public string model { get; set; }
        
        [Required]
        public int year { get; set; }

    }
}