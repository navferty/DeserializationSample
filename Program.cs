using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace DeserializationSample
{
	class Program
	{
		static async System.Threading.Tasks.Task Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var serializer = new XmlSerializer(typeof(CATALOG));
			const string filePath = @"C:\Users\navfe\Desktop\DeserializationSample\catalog.xml";
			var reader = new StreamReader(filePath);
			var data = (CATALOG)serializer.Deserialize(reader);

			if (!data.CD.Any())
			{
				Console.WriteLine("Список пуст!");
				return;
			}

			data.FileName = Path.GetFileNameWithoutExtension(filePath);
			data.LoadedAt = DateTime.UtcNow;

			using var dbContext = new CatalogDbContext();
			dbContext.Add(data);
			await dbContext.SaveChangesAsync();

			Console.WriteLine($"Добавлен каталог {data.Id} с {data.CD.Count} элементами");
		}
	}

	// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
	/// <remarks/>
	[Serializable()]
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public partial class CATALOG
	{
		[XmlIgnore]
		public int Id { get; set; }

		[XmlIgnore]
		public string FileName { get; set; }

		[XmlIgnore]
		public DateTime LoadedAt { get; set; }

		/// <remarks/>
		[XmlElement("CD")]
		public List<CATALOGCD> CD { get; set; }
	}

	/// <remarks/>
	[Serializable()]
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true)]
	public partial class CATALOGCD
	{
		[XmlIgnore]
		public int Id { get; set; }

		/// <remarks/>
		public string TITLE { get; set; }
		/// <remarks/>
		public string ARTIST { get; set; }
		/// <remarks/>
		public string COUNTRY { get; set; }
		/// <remarks/>
		public string COMPANY { get; set; }
		/// <remarks/>
		public decimal PRICE { get; set; }
		/// <remarks/>
		public ushort YEAR { get; set; }
	}
}
