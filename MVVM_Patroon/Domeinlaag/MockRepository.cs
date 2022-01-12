using Domeinlaag.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeinlaag {
	public static class MockRepository {
		public static List<Account> GeefAccounts() {
			return new List<Account>() {
				new(1, "JohnDoe01", "John@Doe.com", "John Doe", "USA", DateTime.UnixEpoch),
				new(2, "JaneDoe87", "Jane@Doe.com", "Jane Doe", "UK", DateTime.UnixEpoch.AddYears(5)),
				new(3, "MaryDoe01", "Mary@Doe.com", "Mary Doe", "Ierland", DateTime.UnixEpoch.AddYears(-10)),
				new(4, "BobDoe01", "Bob@Doe.com", "Bob Doe", "Frankrijk", DateTime.UnixEpoch.AddDays(20)),
				new(5, "JeanDoe01", "Jean@Doe.com", "Jean Doe", "Duitsland", DateTime.UnixEpoch)
			};
		}

		public static List<Product> GeefProducten() {
			return new List<Product>() {
				new(1, "0001-XYZ", "Tuinslang", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus ut risus arcu. Donec mollis felis vulputate, condimentum diam eget, pharetra lectus.", 12.34, 150),
				new(2, "0002-XYZ", "Tuinlamp", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus ut risus arcu. Donec mollis felis vulputate, condimentum diam eget, pharetra lectus.", 12.34, 150),
				new(3, "0003-XYZ", "Grasmaaier", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus ut risus arcu. Donec mollis felis vulputate, condimentum diam eget, pharetra lectus.", 12.34, 150),
				new(4, "0004-XYZ", "Bosmaaier", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus ut risus arcu. Donec mollis felis vulputate, condimentum diam eget, pharetra lectus.", 12.34, 150),
				new(5, "0005-XYZ", "Heggenschaar", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus ut risus arcu. Donec mollis felis vulputate, condimentum diam eget, pharetra lectus.", 12.34, 150),
			};
		}
	}
}
