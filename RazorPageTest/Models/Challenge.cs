using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageTest.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, DefaultValue("")]
        public string Description { get; set; }        
        public string TestValues { get; set; }        
        public string TestResults { get; set; }
    }
}
