using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MapsGuides.Data
{
    public class Dot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String User { get; set; }
        [Required]
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Category { get; set; }
        [Required]
        public String City { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        public String ThumbName { get; set; }
        public String ThumbFile { get; set; }
        public String TimeOpen { get; set; }
        public String TimeClose { get; set; }
        public String Website { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
    }
}
