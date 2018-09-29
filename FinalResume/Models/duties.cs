using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalResume.Models
{
    public class duties
    {
        public int ID { get; set; }
        public string summary { get; set; }
        public int? experienceID { get; set; }
       

        public Experience experience { get; set; }




    }
}
