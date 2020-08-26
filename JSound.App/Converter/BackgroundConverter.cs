using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace JSoundApp.Converter
{
    public sealed class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            ListViewItem item = (ListViewItem)value;
            ListView listView =
                ItemsControl.ItemsControlFromItemContainer(item) as ListView;
            // Get the index of a ListViewItem
            int index =
                listView.ItemContainerGenerator.IndexFromContainer(item);
            var converter = new System.Windows.Media.BrushConverter(); 

            if (index % 2 == 0)
            {
                return (Brush)converter.ConvertFromString("#FFF4F4F6"); ;
            }
            else
            {
                return (Brush)converter.ConvertFromString("#FFFAFAFC");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}