using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace app_xamarin_listing_AL_AP.Utilities
{
    public static class Settings
    {
        public static string Login
        {
            get
            {
                return Preferences.Get("Login", "");
            }
            set
            {
                Preferences.Set("Login", value);
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

        public static bool IsUserConnected
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password))
                {
                    return true;
                }
                return false;
            }
        }
    }
}