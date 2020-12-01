using MapsGuides.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MapsGuides.Models
{
    public class DotModel
    {
        [HiddenInput(DisplayValue = false)]
        public int dot_id { get; set; }
        [Required]
        [Display(Name = "Имя владельца")]
        public String user { get; set; }
        [Display(Name = "Категория")]
        public int category_id { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public String phone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public String email { get; set; }
        [Required]
        [Display(Name = "Город")]
        public String city { get; set; }
        [Required]
        [Display(Name = "Название метки")]
        public String title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public String description { get; set; }
        [Display(Name = "Изображение")]
        public String thumb { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:00}", ApplyFormatInEditMode = true)]
        [Display(Name = "Время открытия")]
        public DateTime time_open { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:00}", ApplyFormatInEditMode = true)]
        [Display(Name = "Время закрытия")]
        public DateTime time_close { get; set; }
        [DataType(DataType.Url)]
        [Display(Name = "Сайт")]
        public String website { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Double latitude { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Double longitude { get; set; }
        public Dot createDot(Dot dot=null)
        {
            if (dot == null)
            {
                dot = new Dot();
            }
            dot.phone = phone;
            dot.email = email;
            dot.city = city;
            dot.title = title;
            dot.description = description;
            dot.time_open = time_open;
            dot.time_close = time_close;
            dot.latitude = latitude;
            dot.longitude = longitude;
            return dot;
        }
    }
}
