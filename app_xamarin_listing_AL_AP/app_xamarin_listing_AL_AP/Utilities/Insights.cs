using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Text;

namespace app_xamarin_listing_AL_AP.Utilities
{
    public class Insights
    {
        public static void ReportError(Exception ex, Dictionary<string, string> properties)
        {
            if (Microsoft.AppCenter.AppCenter.Configured)
            {
                Crashes.TrackError(ex, properties);
            }
            else
            {
                Console.WriteLine("INSIGHT ReportError : " + ex.ToString());
            }
        }

        public static void TrackEvent(string EventName, Dictionary<string, string> properties)
        {
            if (Microsoft.AppCenter.AppCenter.Configured)
            {
                Analytics.TrackEvent(EventName, properties);
            }
            else
            {
                Console.WriteLine("INSIGHT TrackEvent : " + EventName);
            }
        }
    }
}