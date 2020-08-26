using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JSoundApp.Converter
{
    public class SliderValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan currentTime = TimeSpan.Parse(values[0].ToString());
            TimeSpan totaltime = TimeSpan.Parse(values[1].ToString());

            double v = Math.Min(100, (int)(100 * currentTime.TotalSeconds / totaltime.TotalSeconds));
            return v;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
