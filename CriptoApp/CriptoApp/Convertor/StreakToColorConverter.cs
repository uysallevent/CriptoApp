using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CriptoApp.Convertor
{
    public class StreakToColorConverter : IValueConverter
    {
        public static string[] WinStreakColors = new string[] { "#CEF6CE", "#A9F5A9", "#81F781", "#58FA58", "#2EFE2E", "#00FF00", "#01DF01" };
        public static string[] LooseStreakColors = new string[] { "#F5A9A9", "#F78181", "#FA5858", "#FE2E2E", "#FF0000", "#DF0101", "8A0808" };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Color.Transparent;
            int Renk = (int)value;


            if (Renk == 1)
            {
                return Color.FromHex("#A9F5A9");
            }
            else if (Renk == 0)
            {
                return Color.FromHex("#FA5858");
            }
            else
                return Color.FromHex("#e8e594");

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
