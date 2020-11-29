using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MapsGuides.Data
{
    public class Dot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string user_id { get; set; }
        public User User { get; set; }
        public int category_id { get; set; }
        public Categorie Categorie { get; set; }
        [Required]
        public String phone { get; set; }
        public String email { get; set; }
        [Required]
        public String city { get; set; }
        [Required]
        public String title { get; set; }
        [Required]
        public String description { get; set; }
        public String thumb_name { get; set; }
        public String thumb_file { get; set; }
        public DateTime time_open { get; set; }
        public DateTime time_close { get; set; }
        public String website { get; set; }
        public Double latitude { get; set; }
        public Double longitude { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public List<Msg> Msgs { get; set; }
        public List<Payment> Payments { get; set; }
        public Dot()
        {
            Payments = new List<Payment>();
            Msgs = new List<Msg>();
        }
    }
}
