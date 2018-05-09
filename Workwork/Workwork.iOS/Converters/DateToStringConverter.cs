using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Platform.Converters;
using UIKit;

namespace Workwork.iOS.Converters
{
    public class DateToStringConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetString(value);
        }

        public string GetString(DateTime value)
        {
            DateTime today = DateTime.Today.Date;
            TimeSpan days = today - value;
            int daysAgo = days.Days;
            if (daysAgo == 0)
            {
                return "Today";
            }
            else
            {
                return daysAgo.ToString() + " days ago";
            }
        }


    }
}