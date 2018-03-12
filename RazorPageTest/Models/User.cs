using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageTest.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100), Display(Name = "Nickname")]
        public string Nickname { get; set; }
    }
}
