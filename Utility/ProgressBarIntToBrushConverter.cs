using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace DierenTuinWPF.Utility
{
    [ValueConversion(typeof(int), typeof(Brush))]
    public class ProgressBarIntToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int percentFilled = (int)value;

            //Instantiate new brushConverter
            BrushConverter brushConvert = new BrushConverter();
            //Make new Green brush from hex.
            SolidColorBrush colourBrush = (SolidColorBrush)brushConvert.ConvertFrom("#FF3DB108");

            //If less than 15% colour red, less than 35% Yellow.
            if (percentFilled <= 15)
                colourBrush = (SolidColorBrush)brushConvert.ConvertFrom("#FFE41600");
            else if (percentFilled <= 35)
                colourBrush = (SolidColorBrush)brushConvert.ConvertFrom("#FFFFC800");

            return colourBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
