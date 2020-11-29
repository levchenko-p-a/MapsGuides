using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MapsGuides.Data
{
    public class Msg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int dot_id { get; set; }
        public Dot dot { get; set; }
        public string user_id { get; set; }
        public User User { get; set; }
        public string text { get; set; }
    }
}
