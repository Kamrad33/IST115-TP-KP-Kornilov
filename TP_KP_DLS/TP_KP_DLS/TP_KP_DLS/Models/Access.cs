using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_KP_DLS.Models
{
    public class Access
    {
        public int ID_Access { get; set; }
        public int Access_ID_Subject { get; set; }
        public string Access_ID_User{ get; set; }
    }
}