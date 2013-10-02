using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyDesign.ViewModel.Entities;

namespace MonopolyDesign.Contracts
{
	public interface IFileService
	{
		void Save(IEnumerable<ItemViewModel> items);
		IEnumerable<ItemViewModel> Load();
	}
}
