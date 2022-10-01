using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenceTrackerWebApp.Models
{
    public class Income

    {
        [Key]
        public int Id { get; set; }
        public DateTime PlacementDate { get; set; } = DateTime.Now;
        [Required]
        public Decimal Amount { get; set; }
        [Required]
        public string Description { get; set; }
        public Income()
        {

        }
    }
}
