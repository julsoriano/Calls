using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calls.Models
{
    public class Phone
    {
        public int PhoneID { get; set; }
        public int CallID { get; set; }
        public IDictionary<string, string> PhoneOne { get; set; }
    }
}