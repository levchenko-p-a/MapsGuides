using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MapsGuides.Data
{
    public class User : IdentityUser
    {
        public String first_name { get; set; }
        public String second_name { get; set; }
        public int register_service_id { get; set; }
        public RegisterService RegisterService { get; set; }
        public String register_code { get; set; }
        public int rating { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public List<Dot> Dots { get; set; }
        public List<Categorie> Categories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Msg> Msgs { get; set; }
        public User()
        {
            Dots = new List<Dot>();
            Categories = new List<Categorie>();
            Comments = new List<Comment>();
            Payments = new List<Payment>();
            Msgs = new List<Msg>();
        }
    }
}
