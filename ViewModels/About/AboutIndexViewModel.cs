﻿using PurpleBuzz.Models;

namespace PurpleBuzz.ViewModels.About
{
    public class AboutIndexViewModel
    {
        public List<Cards> Cards { get; set; }
        public List<Contact> Contact { get; internal set; }
    }
}
