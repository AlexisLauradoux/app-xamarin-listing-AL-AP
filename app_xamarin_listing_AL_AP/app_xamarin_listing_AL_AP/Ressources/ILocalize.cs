using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace app_xamarin_listing_AL_AP.Ressources
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);
    }
}