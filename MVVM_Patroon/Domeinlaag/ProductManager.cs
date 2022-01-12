using Domeinlaag.Model;
using System;
using System.Collections.Generic;

namespace Domeinlaag {
	public class ProductManager {
		public List<Product> GeefProducten() {
			return MockRepository.GeefProducten();
		}
	}
}
