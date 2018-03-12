using Microsoft.EntityFrameworkCore;
using RazorPageTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageTest
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opts) : base(opts)
        {
            Database.EnsureCreated();

            #region seeding
            if (!Users.Any())
            {
                Users.Add(new User()
                {
                    Id = 1,
                    Nickname = "Jack"
                });
                Users.Add(new User()
                {
                    Id = 2,
                    Nickname = "Pukuotukas"
                });
                Users.Add(new User()
                {
                    Id = 3,
                    Nickname = "Folija"
                });
                Users.Add(new User()
                {
                    Id = 4,
                    Nickname = "Do you smell what the rock is cooking"
                });
                Users.Add(new User()
                {
                    Id = 5,
                    Nickname = "Simon"
                });
                SaveChanges();
            }

            if (!Challenges.Any())
            {
                Challenges.Add(new Challenge()
                {
                    Id = 1,
                    Name = "Fibonacci",
                    Description = "Write a program that prints the nth number of fibonacci sequence",
                    TestValues = "0;1;2;3;4;5;6;7;8;9;10",
                    TestResults = "0;1;1;2;3;5;8;13;21;34"

                });

                Challenges.Add(new Challenge()
                {
                    Id = 2,
                    Name = "Petrusevionacci",
                    Description = "Write a program that prints the square of a number",
                    TestValues = "21;34",
                    TestResults = "441;1156"
                    
                });
                SaveChanges();
            }

            if (!CompletedChallenge.Any() && Users.Any() && Challenges.Any())
            {
                CompletedChallenge.Add(new CompletedChallenge()
                {
                    Id = 1,
                    Challenge = Challenges.First(),
                    User = Users.First(),
                    Source = ""
                });

                CompletedChallenge.Add(new CompletedChallenge()
                {
                    Id = 2,
                    Challenge = Challenges.Last(),
                    User = Users.Last(),
                    Source = ""
                });

                CompletedChallenge.Add(new CompletedChallenge()
                {
                    Id = 3,
                    Challenge = Challenges.Last(),
                    User = Users.First(),
                    Source = ""
                });

                SaveChanges();
            }
            #endregion
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<CompletedChallenge> CompletedChallenge { get; set; }
    }
}
