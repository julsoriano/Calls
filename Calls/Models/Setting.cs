using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calls.Models
{
    public class Setting
    {
        //[ScaffoldColumn(false)]
        public int SettingId { get; set; }

        [StringLength(10)]
        [DisplayName("Cong. ID")]
        public string CongregationID { get; set; }

        public int? InitialScreen { get; set; }
    }
}
