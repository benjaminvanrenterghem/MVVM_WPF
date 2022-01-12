using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeinlaag.Model {
	public class Account {
		public int Id { get; set; }
		public string Gebruikersnaam { get; set; }
		public string Email { get; set; }
		public string Naam { get; set; }
		public string Land { get; set; }
		public DateTime Geboortedatum { get; set; }

		public Account(int id, string gebruikersnaam, string email, string naam, string land, DateTime geboortedatum) {
			Id = id > 0 ? id : throw new ArgumentException(nameof(id));
			Gebruikersnaam = gebruikersnaam ?? throw new ArgumentNullException(nameof(gebruikersnaam));
			Email = email ?? throw new ArgumentNullException(nameof(email));
			Naam = naam ?? throw new ArgumentNullException(nameof(naam));
			Land = land ?? throw new ArgumentNullException(nameof(land));
			Geboortedatum = geboortedatum;
		}
	}
}
