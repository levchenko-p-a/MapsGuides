using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapsGuides.Data
{
    public class Categorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string user_id { get; set; }
        public User User { get; set; }
        [Required]
        public String name { get; set; }
        public String description { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public List<Dot> Dots { get; set; }
        public Categorie()
        {
            Dots = new List<Dot>();
        }
    }
}
