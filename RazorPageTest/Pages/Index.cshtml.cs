using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageTest.Code;
using RazorPageTest.Models;
using RazorPageTest.Models.ViewModels;

namespace RazorPageTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        private readonly ISubmissionValidationService _submissionValidationService;

        [BindProperty]
        public ChallengeSubmissionViewModel Submission { get; set; }
        public IndexModel(AppDbContext db, ISubmissionValidationService submissionService)
        {
            _db = db;
            _submissionValidationService = submissionService;

        }
        public string Message { get; set; }

        public List<Challenge> Challenges {
            get
            {
                return _db.Challenges.ToList();
            }
        }

        public List<User> Customers { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _db.Users.SingleOrDefault(x => x.Nickname == Submission.Nickname);

            if (user != null)
            {
                var challenge = await _db.CompletedChallenge.Where(x => x.UserId == user.Id && x.ChallengeId == Submission.ChallengeId).ToListAsync();

                if (challenge.Count != 0)
                {
                    TempData["Message"] = "Submission was already placed.";
                    return RedirectToPage("/Index");
                }
            }

            var result = _submissionValidationService.ValidateSubmission(Submission);

            if (result)
            {
                

                if (user == null)
                {
                    user = new User() { Nickname = Submission.Nickname };
                }

                await _db.CompletedChallenge.AddAsync(new CompletedChallenge()
                {
                    ChallengeId = Submission.ChallengeId,
                    User = user,
                    Source = Submission.Source
                });

                await _db.SaveChangesAsync();
                TempData["Message"] = "Submission successful";
            } else
            {
                TempData["Message"] = "Submission failed";
            }
                
            return RedirectToPage("/Index");
        }
    }
}