using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;

namespace MonopolyDesign.ViewModel.Entities
{
	public class ItemViewModel : ViewModelBase
	{
		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				RaisePropertyChanged(() => Name);
			}
		}

		private Color _color;
		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
				RaisePropertyChanged(() => Color);
			}
		}

		private CountryViewModel _country;
		public CountryViewModel Country
		{
			get
			{
				return _country;
			}
			set
			{
				_country = value;
				RaisePropertyChanged(() => Country);
			}
		}

		private readonly List<PricesViewModel> _prices = new List<PricesViewModel>()
			{
				new PricesViewModel(),
				new PricesViewModel(),
				new PricesViewModel()
			};

		public List<PricesViewModel> Prices
		{
			get
			{
				return _prices;
			}
		}
	}

	public class CountryViewModel : ViewModelBase
	{
		public CountryViewModel(string name, string filename)
		{
			Name = name;
			
			if (filename != null)
				Flag = new BitmapImage(new Uri(string.Format("pack://application:,,,/Flags/{0}", filename)));
		}

		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				RaisePropertyChanged(() => Name);
			}
		}

		private ImageSource _flag;
		public ImageSource Flag
		{
			get
			{
				return _flag;
			}
			set
			{
				_flag = value;
				RaisePropertyChanged(() => Flag);
			}
		}
	}

	public class PricesViewModel : ViewModelBase
	{
		private int _buyPrice;
		public int BuyPrice
		{
			get
			{
				return _buyPrice;
			}
			set
			{
				_buyPrice = value;
				RaisePropertyChanged(() => BuyPrice);
			}
		}

		private int _incomePrice;
		public int IncomePrice
		{
			get
			{
				return _incomePrice;
			}
			set
			{
				_incomePrice = value;
				RaisePropertyChanged(() => IncomePrice);
			}
		}
	}
}
