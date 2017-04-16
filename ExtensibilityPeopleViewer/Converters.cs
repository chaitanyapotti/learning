using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ExtensibilityPeopleViewer
{
    class DecadeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int year = ((DateTime)value).Year;
            return $"{year.ToString().Substring(0, 3)}0's";
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rating = (int)value;
            return $"{rating}/10 Stars";
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class RatingStarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rating = (int)value;
            string output = string.Empty;
            return output.PadLeft(rating, '*');

            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = value.ToString();
            return input.Count(x => x == '*');
            //throw new NotImplementedException();
        }
    }
    public class DecadeBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int decade = (((DateTime)value).Year / 10) * 10;

            switch (decade)
            {
                case 1970:
                    return new SolidColorBrush(Colors.Maroon);
                case 1980:
                    return new SolidColorBrush(Colors.DarkGreen);
                case 1990:
                    return new SolidColorBrush(Colors.DarkSlateBlue);
                case 2000:
                    return new SolidColorBrush(Colors.CadetBlue);
                default:
                    return new SolidColorBrush(Colors.DarkSlateGray);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
