using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MapsGuides.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Телефон")]
        public string phone { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Логин")]
        public string login { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string first_name { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string second_name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        [Display(Name = "Пароль")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string password_confirm { get; set; }
    }
}
