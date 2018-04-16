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
    public class BoolToErrorColorConverter : MvxValueConverter<bool, UIColor>
    {
        protected override UIColor Convert(bool error, Type targetType, object parameter, CultureInfo culture)
        {
            return GetColor(error);
        }

        public UIColor GetColor(bool error)
        {
            if (error)
            {
                return UIColor.Red;
            }
            else
            {
                return UIColor.Black;
            }
        }
    }
}