using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeinlaag.Model {
	public class Product {
		public int Id { get; set; }
		public string SKU { get; set; }
		public string Naam { get; set; }
		public string Beschrijving { get; set; }
		public double Gewicht { get; set; }
		public int Stock { get; set; }

		public Product(int id, string sku, string naam, string beschrijving, double gewicht, int stock) {
			Id = id > 0 ? id : throw new ArgumentException(nameof(id));
			SKU = sku ?? throw new ArgumentNullException(nameof(sku));
			Naam = naam ?? throw new ArgumentNullException(nameof(naam));
			Beschrijving = beschrijving ?? throw new ArgumentNullException(nameof(beschrijving));
			Gewicht = gewicht;
			Stock = stock;
		}
	}
}
