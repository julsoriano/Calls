using System.ComponentModel.DataAnnotations;

namespace Calls.Models
{
    public class Barangay
    {       
        public int BarangayId { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "{0} is required")]
        public string City { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "{0} is required")]
        public string State { get; set; }
    }
}