using System.ComponentModel.DataAnnotations;


namespace Calls.Models
{
    public class Title
    {
        [ScaffoldColumn(false)]
        public int TitleID { get; set; }

        [StringLength(10)]
        public string abbrTitle { get; set; }

        [StringLength(20)]
        public string fullTitle { get; set; }
    }
}