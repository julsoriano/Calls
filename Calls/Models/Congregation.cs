using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calls.Models
{
    public class Congregation
    {       
        public int CongregationId { get; set; }

        [StringLength(10)]
        [DisplayName("Congregation Number")]
        public string CongregationCode { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(25)]
        public string Barangay { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        [StringLength(25)]
        public string State { get; set; }

        [StringLength(25)]
        public string Country { get; set; }

        [StringLength(15)]
        public string PostCode { get; set; }   

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        [DisplayName("Mobile Phone")]
        public string phoneMobile { get; set; }

        [StringLength(20)]
        [DisplayName("Landline")]
        public string phoneLandline { get; set; }
    }
}