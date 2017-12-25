using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP_KP_DLS.Models
{
    public class Book
    {
        public int ID_Book { get; set; }

        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [StringLength(200, ErrorMessage = "Максимум 200 символов")]
        [Display(Name = "Фамилия автора")]
        public string Book_Author_Surname { get; set; }


        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [StringLength(200, ErrorMessage = "Максимум 200 символов")]
        [Display(Name = "Имя автора")]
        public string Book_Author_Name { get; set; }


        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [StringLength(500, ErrorMessage = "Максимум 500 символов")]
        [Display(Name = "Название книги")]
        public string Book_Name { get; set; }


        [StringLength(500, ErrorMessage = "Максимум 500 символов")]
        [Display(Name = "Ссылка")]
        public string Book_Link { get; set; }

        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [RegularExpression("([1-30])", ErrorMessage = "Номер предмета должен состоять из цифр")]
        [Display(Name = "Номер предмета")]
        public int Book_ID_Subject { get; set; }


        public List<Book> ListBook { get; set; }
    }
}