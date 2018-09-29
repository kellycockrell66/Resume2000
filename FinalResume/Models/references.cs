using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalResume.Models
{
    public class references
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string companyName { get; set; }
        public string mailingAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string emailAddress { get; set; }
        public string phone { get; set; }
        public int? applicantID { get; set; }

        public applicant applicant { get; set; }














    }
}
