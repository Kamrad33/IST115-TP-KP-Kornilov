using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP_KP_DLS.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
       
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
       
       
        public DateTime LockoutEndDateUtc { get; set; }
        
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string UserRealName { get; set; }
        public string UserRealSurname { get; set; }
        public string UserRealPatronymic { get; set; }

    


    }
}