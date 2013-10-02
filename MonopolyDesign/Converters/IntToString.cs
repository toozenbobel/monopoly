using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MonopolyDesign.Converters
{
	public class IntToString : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int)
			{
				return value.ToString();
			}

			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
			{
				return System.Convert.ToInt32(value);
			}

			return 0;
		}
	}
}
