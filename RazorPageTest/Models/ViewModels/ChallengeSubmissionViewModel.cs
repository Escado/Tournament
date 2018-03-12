using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageTest.Models.ViewModels
{
    public class ChallengeSubmissionViewModel
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public int ChallengeId { get; set; }
    }
}
