using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalResume.Models
{
    public class Experience
    {   
        public int ID { get; set; }
        public string jobName { get; set; }
        public string placeWorked { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int? applicantID { get; set; }

        public applicant applicant { get; set; }
        public List<duties> duty {get; set;}
    }
}
