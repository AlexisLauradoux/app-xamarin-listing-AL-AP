using app_xamarin_listing_AL_AP.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace app_xamarin_listing_AL_AP.Utilities
{
    public static class Settings
    {
        public static string Email
        {
            get
            {
                return Preferences.Get("Email", "");
            }
            set
            {
                Preferences.Set("Email", value);
            }
        }

        public static string Password
        {
            get
            {
                return Preferences.Get("Password", "");
            }
            set
            {
                Preferences.Set("Password", value);
            }
        }

        public static string Token
        {
            get
            {
                return Preferences.Get("Token", "");
            }
            set
            {
                Preferences.Set("Token", value);
            }
        }

        //public static string Id
        //{
        //    get
        //    {
        //        return Preferences.Get("Id", null);
        //    }
        //    set
        //    {
        //        Preferences.Set("Id", value);
        //    }
        //}

        public static bool IsConnected
        {
            get
            {
                return Preferences.Get("IsConnected", false);
            }
            set
            {
                Preferences.Set("IsConnected", value);
            }
        }
    }
}