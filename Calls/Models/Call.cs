using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calls.Models
{
    //[Bind(Exclude = "ID")]
    public class Call
    {
        //[ScaffoldColumn(false)]
        public int ID { get; set; }

        [StringLength(10)]
        [DisplayName("Cong. ID")]
        public string CongregationID { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "{0} is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(25, ErrorMessage = "{0} can not be longer than 25 characters.")]
        [DisplayName("First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string nameFirst { get; set; }

        [StringLength(25, ErrorMessage = "{0} can not be longer than 25 characters.")]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string nameLast { get; set; }

        [StringLength(50, ErrorMessage = "{0} can not be longer than 50 characters.")]
        public string Street { get; set; }

        [StringLength(25, ErrorMessage = "{0} can not be longer than 25 characters.")]
        public string Barangay { get; set; }

        [StringLength(25, ErrorMessage = "{0} can not be longer than 25 characters.")]
        public string City { get; set; }

        [StringLength(25, ErrorMessage = "{0} can not be longer than 25 characters.")]
        public string State { get; set; }

        //[StringLength(50)]
        //[DataType(DataType.EmailAddress)]
        public IDictionary<string, string> Email { get; set; }
        //public string Email { get; set; }

        // See "How to: Initialize a Dictionary with a Collection Initializer": http://msdn.microsoft.com/en-us/library/vstudio/bb531208.aspx
        // public IDictionary<string, string> Phones { get; set; } 

        //[StringLength(20)]         
        //[DisplayName("Mobile Phone")]
        //public string phoneMobile { get; set; }

        //[StringLength(20)]
        //[DisplayName("Landline")]
        //public string phoneLandline { get; set; }

        [DataType(DataType.Date)]  
        //[DisplayFormat(DataFormatString = "{0:ddMMMyy}")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DisplayName("First Visit")]
        public DateTime dateFirstVisit { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:ddMMMyy}")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DisplayName("Last Visit")]
        public DateTime dateLastVisit { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        /*
         * FullName is a calculated property that returns a value that's created by concatenating two other properties. 
         * Therefore it has only a get accessor, and no FullName column will be generated in the database. 
         * See http://www.asp.net/mvc/tutorials/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application
         * 
         * Unable to use Calculated Property. Error message:
         * An exception of type 'System.NotSupportedException' occurred in mscorlib.dll (return View(calls.ToList()); in CallController>Index) 
         * but was not handled in user code
         * 
         * Additional information: The specified type member 'FullName' is not supported in LINQ to Entities. 
         * Only initializers, entity members, and entity navigation properties are supported.
         * 
         */
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return (String.IsNullOrEmpty(nameFirst) ? "" : nameFirst + " ") + nameLast;
            }
        }

        [Display(Name = "Full Address")]
        public string FullAddress
        {
            get
            {
                return (String.IsNullOrEmpty(Street) ? "" : Street + ", ") +
                    (String.IsNullOrEmpty(Barangay) ? "" : Barangay + ", ") + 
                    (String.IsNullOrEmpty(Street) ? "" : City + ", ") + State;
            }
        }

        //public List<Address> Addresses { get; set; }
        public List<Phone> Phones { get; set; }
        //public List<EmailAddress> EmailAddresses { get; set; }
    }
}
