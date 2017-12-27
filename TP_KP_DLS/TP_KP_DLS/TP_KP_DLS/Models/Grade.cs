using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_KP_DLS.Models
{
    public class Grade
    {
        public int ID_Grade { get; set; }
        public int Grade_ID_Student { get; set; }
        public int Grade_Count { get; set; }
        public int ID_Test { get; set; }
    }
}