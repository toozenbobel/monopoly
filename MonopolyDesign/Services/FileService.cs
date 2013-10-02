using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyDesign.Contracts;
using MonopolyDesign.ViewModel.Entities;
using Newtonsoft.Json;

namespace MonopolyDesign.Services
{
	public class FileService : IFileService
	{
		private const string FILENAME = "db.txt";

		public void Save(IEnumerable<ItemViewModel> items)
		{
			string json = JsonConvert.SerializeObject(items);
			using (FileStream saveTo = File.OpenWrite(FILENAME))
			{
				using (StreamWriter writer = new StreamWriter(saveTo))
				{
					writer.Write(json);
				}
			}
		}

		public IEnumerable<ItemViewModel> Load()
		{
			if (!File.Exists(FILENAME))
				return null;
			
			using (FileStream loadFrom = File.OpenRead(FILENAME))
			{
				using (StreamReader reader = new StreamReader(loadFrom))
				{
					string json = reader.ReadToEnd();
					return JsonConvert.DeserializeObject<IEnumerable<ItemViewModel>>(json);
				}
			}
		}
	}
}
