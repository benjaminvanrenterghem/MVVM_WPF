using BasisToepassing.MVVM.Core;
using BasisToepassing.MVVM.Core.Interfaces;
using Domeinlaag;
using Domeinlaag.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasisToepassing.MVVM.Views {
	internal class AccountViewModel : Presenteerder, IViewModel {
		public string Naam => "Account";
        private AccountManager _accountManager;

        // Bindings
        public string Gebruikersnaam { get; set; }
        public string Email { get; set; }
        public string AccountNaam { get; set; }
        public string Land { get; set; }
        public DateTime Geboortedatum { get; set; }

        // Voert uit bij het renderen (Loaded event) en wordt geprefereerd boven het gebruik van een constructor.
        // Aangezien het ApplicatieOverzichtViewModel bij instantiering alle ViewModels instantieert zou dit
        // anders kunnen leiden tot een resource-spike bij opstart van de applicatie.
        // --- Dit is vooral van belang bij overzichten met grote volumes data.
        // (i) Indien rerender niet gewenst is kan een boolean + check opgenomen worden, zie ProductenViewModel
        private void StartupRoutine() {
            _accountManager = new();

            Random random = new Random();
            List<Account> accounts = _accountManager.GeefAccounts();

            Account rando = accounts[random.Next(accounts.Count)];

            this.Gebruikersnaam = rando.Gebruikersnaam;
            this.Email = rando.Email;
            this.AccountNaam = rando.Naam;
            this.Land = rando.Land;
            this.Geboortedatum = rando.Geboortedatum;
        }

        public RelayCommand BeginStartupRoutine =>
            new (
                f => this.StartupRoutine(),
                param => param is not null
        );
    }
}
