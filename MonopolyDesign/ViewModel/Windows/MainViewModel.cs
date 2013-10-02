using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MonopolyDesign.Contracts;
using MonopolyDesign.ViewModel.Entities;

namespace MonopolyDesign.ViewModel.Windows
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
	    private readonly IFileService _fileService;

	    /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IFileService fileService, ICountriesLoader countriesLoader)
        {
	        _fileService = fileService;

		    var items = _fileService.Load();
			if (items != null)
				foreach (var itemViewModel in items)
				{
					Items.Add(itemViewModel);
				}

		    var countries = countriesLoader.Load();
			if (countries != null)
				foreach (var countryViewModel in countries.OrderBy(c => c.Name))
				{
					Countries.Add(countryViewModel);
				}

		    NewItem.Country = Countries.FirstOrDefault();
        }

	    private ItemViewModel _newItem = new ItemViewModel();
	    public ItemViewModel NewItem
	    {
		    get
		    {
			    return _newItem;
		    }
		    set
		    {
			    _newItem = value;
			    RaisePropertyChanged(() => NewItem);
		    }
	    }

	    private readonly ObservableCollection<ItemViewModel> _items = new ObservableCollection<ItemViewModel>();
	    public ObservableCollection<ItemViewModel> Items
	    {
			get
			{
				return _items;
			}
	    }

	    public ICommand AddCommand
	    {
		    get
		    {
			    return new RelayCommand(Add);
		    }
	    }

		private readonly ObservableCollection<CountryViewModel> _countries = new ObservableCollection<CountryViewModel>();
	    public ObservableCollection<CountryViewModel> Countries
	    {
		    get
		    {
			    return _countries;
		    }
	    }

	    private void Add()
	    {
		    Items.Add(NewItem);

		    var newItem = new ItemViewModel();
		    newItem.Name = NewItem.Name;
		    newItem.Color = NewItem.Color;

			NewItem = newItem;
			NewItem.Country = Countries.FirstOrDefault();
			NewItem.Prices[0].BuyPrice = 0;
			NewItem.Prices[1].BuyPrice = 0;
			NewItem.Prices[2].BuyPrice = 0;
			NewItem.Prices[0].IncomePrice = 0;
			NewItem.Prices[1].IncomePrice = 0;
			NewItem.Prices[2].IncomePrice = 0;
			
			_fileService.Save(Items);
	    }
    }
}