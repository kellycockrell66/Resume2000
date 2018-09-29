using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalResume.Models
{
    public class applicant
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebAddress { get; set; }

        public List <skills> skills {get; set;}
        public List<education> education { get; set; }
        public List<references>reference { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<duties> duty { get; set; }




    }
}
