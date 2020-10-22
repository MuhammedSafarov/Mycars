using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mycars.Models
{
    public class Brands
    {
        [Key]
        [Required]
        public int Id { get; set; }

        //  private readonly string name

        public string GetName()
        {
            return brand;
        }

        public void SetName(string value)
        {
            brand = value;
        }

        [Required]
        public string model { get; set; }

        [Required]
        public int year { get; set; }
        public string brand { get; internal set; }

        public List<Features> Features { get; set; }

    }
}