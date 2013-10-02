using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyDesign.Contracts;
using MonopolyDesign.ViewModel.Entities;

namespace MonopolyDesign.Services
{
	public class CountriesLoader : ICountriesLoader
	{
		public IEnumerable<CountryViewModel> Load()
		{
			List<CountryViewModel> countries = new List<CountryViewModel>
				{
					new CountryViewModel("Швеция", "sweden.jpg"),
					new CountryViewModel("Германия", "germany.jpg"),
					new CountryViewModel("Канада", "canada.jpg"),
					new CountryViewModel("Россия", "russia.jpg"),
					new CountryViewModel("Япония", "japan.jpg"),
					new CountryViewModel("США", "usa.jpg"),
					new CountryViewModel("Испания", "spain.jpg"),
					new CountryViewModel("Франция", "france.jpg"),
					new CountryViewModel("Италия", "italy.jpg"),
				};

			return countries;
		}
	}
}
