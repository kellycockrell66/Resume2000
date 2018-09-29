using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalResume.Models
{
    public class education
    {
        public int ID { get; set; }
        public string degreeType { get; set; }
        public string subject { get; set; }
        public string institution { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string gradDate { get; set; }
        public int? applicantID { get; set; }

        public applicant applicant { get; set; }
    }
}
