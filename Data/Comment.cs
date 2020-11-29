using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapsGuides.Data
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string user_id { get; set; }
        public User User { get; set; }
        public int dot_id { get; set; }
        public int parent_id { get; set; }
        public String text { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
    }
}
