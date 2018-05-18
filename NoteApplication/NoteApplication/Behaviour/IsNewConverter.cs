using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;

namespace NoteApplication.Behaviour
{
    public class IsNewConverter : IValueConverter
    {
        /// <param name="value">the ID</param>
        /// <param name="parameter">(bool) true to invert</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var id = (int)value;
            var invert = (parameter != null) && bool.Parse((string)parameter);

            // Invert value flag ?
            return (invert) ? id != 0 : id == 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
