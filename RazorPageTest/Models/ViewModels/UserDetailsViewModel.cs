﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageTest.Models.ViewModels
{
    public class UserDetailsViewModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int Score { get; set; }
    }
}
