using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace DierenTuinWPF.Utility
{
    class ProgressBarIntToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int percentFilled = (int)value;
            Brush colourBrush = Brushes.DarkGreen;

            if (percentFilled <= 30)
            {
                colourBrush = Brushes.Yellow;
            }
            else if (percentFilled <= 10)
            {
                colourBrush = Brushes.Red;
            }

            return colourBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
