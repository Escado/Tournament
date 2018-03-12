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
            var result = _submissionValidationService.ValidateSubmission(Submission);

            if (result)
            {
                await _db.CompletedChallenge.AddAsync(new CompletedChallenge()
                {
                    ChallengeId = Submission.ChallengeId,
                    User = new User() { Nickname = Submission.Nickname },
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