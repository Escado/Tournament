using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageTest.Models.ViewModels
{
    public class StatisticsViewModel
    {
        public List<UserDetailsViewModel> Scores { get; set; } = new List<UserDetailsViewModel>();
    }
}
