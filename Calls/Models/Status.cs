using System.ComponentModel.DataAnnotations;

namespace Calls.Models
{
    public class Status
    {
        [ScaffoldColumn(false)]
        public int StatusID { get; set; }

        [StringLength(10)]
        public string StatusCode { get; set; }

        [StringLength(20)]
        public string Description { get; set; }
    }
}