using System;
using System.Globalization;
using System.Windows.Data;

namespace JSound.App.Converter
{
    public class VolumeConverter : IValueConverter
    {
        //源属性传给目标属性时，调用此方法ConvertBack
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int c = System.Convert.ToInt32(parameter);
            if (value == null)
                throw new ArgumentNullException("value can not be null");

            float vol = float.Parse(value.ToString());

            return vol * 100.0f;
        }

        //目标属性传给源属性时，调用此方法ConvertBack
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int c = System.Convert.ToInt32(parameter);
            if (value == null)
                throw new ArgumentNullException("value can not be null");

            float vol = float.Parse(value.ToString());
            float res = vol / 100;

            return res;
        }

    }
}
