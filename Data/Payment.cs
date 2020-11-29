using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapsGuides.Data
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int dot_id { get; set; }
        public Dot dot { get; set; }
        public string user_id { get; set; }
        public User User { get; set; }
        public int markup { get; set; } //наценка
        public int status_id { get; set; }
        public int amount { get; set; }//сумма без наценки
        public DateTime created { get; set; }
    }
}
