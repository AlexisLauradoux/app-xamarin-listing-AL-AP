﻿using System;
using System.Collections.Generic;
using System.Text;

namespace app_xamarin_listing_AL_AP.Models
{
    public enum MenuItemType
    {
        Browse,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}