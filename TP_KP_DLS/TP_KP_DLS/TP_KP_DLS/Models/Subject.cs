using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP_KP_DLS.Models
{
    public class Subject
    {
        public int ID_Subject { get; set; }

        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [StringLength(300, ErrorMessage = "Максимум 300 символов")]
        [Display(Name = "Название предмета")]
        public string Subject_Name { get; set; }
    }
}