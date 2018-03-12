using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageTest.Models
{
    public class CompletedChallenge
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public Challenge Challenge { get; set; }

        [Required]
        public string Source { get; set; }

        [ForeignKey("Challenge")]
        public int ChallengeId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
