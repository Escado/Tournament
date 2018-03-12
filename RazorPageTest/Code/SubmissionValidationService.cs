using CompilerApp;
using Microsoft.CSharp;
using RazorPageTest.Models.ViewModels;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RazorPageTest.Code
{
    public interface ISubmissionValidationService
    {
        bool ValidateSubmission(ChallengeSubmissionViewModel submission);
    }

    public class SubmissionValidationService : ISubmissionValidationService
    {
        private readonly AppDbContext _db;
        public SubmissionValidationService(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public bool ValidateSubmission(ChallengeSubmissionViewModel submission)
        {
            var challenge = _db.Challenges.Single(x => x.Id == submission.ChallengeId);
            return Compiler.Compile(submission.Source, challenge.TestValues, challenge.TestResults);
        }
    }
}

