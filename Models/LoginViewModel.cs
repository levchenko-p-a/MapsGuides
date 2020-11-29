using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MapsGuides.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool remember_me { get; set; }

        public string return_url { get; set; }
    }
}
