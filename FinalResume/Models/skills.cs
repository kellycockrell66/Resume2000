using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalResume.Models
{
    public class skills
    {
        public int ID { get; set; }
        public string skillName { get; set; }
        public string experienceLevel { get; set; }
        public string  yearsUsed { get; set; }
        public int? applicantID { get; set; }

        public applicant applicant { get; set; }
    }
}
