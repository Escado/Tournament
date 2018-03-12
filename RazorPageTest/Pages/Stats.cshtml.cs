using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageTest;
using RazorPageTest.Models;
using RazorPageTest.Models.ViewModels;

namespace RazorPageTest.Pages
{
    public class StatsModel : PageModel
    {
        private readonly AppDbContext _context;
        public StatisticsViewModel Statistics { get; set; } = new StatisticsViewModel();

        public StatsModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            var list = Statistics.Scores;

            var data = await _context.CompletedChallenge.Include(x => x.User).Include(x => x.Challenge).ToListAsync();

            UserDetailsViewModel userDetails;
            foreach (var item in data)
            {
                userDetails = list.SingleOrDefault(x => x.Id == item.UserId);
                if (userDetails == null)
                {
                    list.Add(new UserDetailsViewModel()
                    {
                        Id = item.User.Id,
                        Nickname = item.User.Nickname,
                        Score = 1
                    });
                }
                else
                {
                    userDetails.Score++;
                }

            }
        }
    }
}
