using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenceTrackerWebApp.Models
{
    public class Expence
    {
        [Key]
        public int Id { get; set; }
        public DateTime ExpenceDate { get; set; } = DateTime.Now;
        [Required]
        public Decimal  Cost { get; set; }
        [Required]
        public string Description { get; set; }
        public Expence()
        {

        }

    }
}
