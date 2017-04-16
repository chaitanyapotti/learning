using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace PeopleViewer.Layered
{
    public class DecadeConverter : IValueConverter
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

    public class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rating = (int)value;
            return $"{rating}/10 stars";
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RatingStarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rating = (int)value;
            string star = string.Empty;
            return star.PadLeft(rating, '*');
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
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
