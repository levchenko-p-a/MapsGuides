using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MapsGuides.Data
{
    public class RegisterService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public List<User> Users { get; set; }
        public RegisterService()
        {
            Users = new List<User>();
        }
    }
}
