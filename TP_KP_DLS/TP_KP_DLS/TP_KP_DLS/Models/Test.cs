using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP_KP_DLS.Models
{
    public class Test
    {
        public int ID_Test { get; set; }
        public int Test_ID_Subject{ get; set; }
        public string Test_Name { get; set; }
    }
}