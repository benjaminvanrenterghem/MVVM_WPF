using BasisToepassing.MVVM.Core;
using BasisToepassing.MVVM.Core.Exceptions;
using BasisToepassing.MVVM.Core.Interfaces;
using BasisToepassing.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasisToepassing {
	/*
		Beheert de View(Model) instanties en het ActieveViewModel.
		Stelt beheerfunctionaliteiten middels RelayCommands beschikbaar aan de Views.

		Dit ViewModel stelt een eis mbt naamgeving in functies 
		ResetViewModel en WijzigActiefViewModel, namelijk:
		- Het beheerde ViewModel draagt de naam van de View met "ViewModel" toegevoegd op het einde
	*/
	// De overerving van Presenteerder impliceert behandeling van de klasse door PropertyChanged.Fody
	internal sealed class ApplicatieOverzichtViewModel : Presenteerder, IViewModel {

		public string Naam => "MVVM applicatie";

		// Bepaalt welke View zichtbaar is in ApplicatieOverzicht
		public IViewModel ActieveViewModel { get; private set; }

		public Dictionary<string, IViewModel> BeheerdeViewModels { get; init; }

		public ApplicatieOverzichtViewModel() {
			// ViewModels onder beheer plaatsen, hun verbanden zijn tevens vermeld in de View
			BeheerdeViewModels = new() {
				{ nameof(IntroductieView), new IntroductieViewModel() },
				{ nameof(ProductenView), new ProductenViewModel() },
				{ nameof(AccountView), new AccountViewModel() },
				{ nameof(InstellingenView), new InstellingenViewModel() },
				{ nameof(PrivacyInstellingenView), new PrivacyInstellingenViewModel() }
			};

			// Bepalen welke View als eerste weer te geven
			ActieveViewModel = BeheerdeViewModels[nameof(IntroductieView)];
		}

		// Laat toe om een nieuw ViewModel aan te maken 
		// Wordt lokaal gebruikt voor het resetten van een ViewModel
		private object MaakNieuwViewModel(IViewModel viewModel) {
			// De parameters om het ViewModel mee te instantieren, indien ViewModels verschillen qua
			// parameters kan er op basis van naam/interface andere parameters doorgegeven worden
			var parameters = new object[] { };

			try {
				object instantie = Activator.CreateInstance(viewModel.GetType(), parameters);

				// Indien het ViewModel voorzien is van een StartupRoutine Command dan wordt deze aangeroepen
				if (instantie.GetType().GetProperty("BeginStartupRoutine") != null) {
					var commando = instantie.GetType().GetProperty("BeginStartupRoutine").GetGetMethod(true).Invoke(instantie, Array.Empty<object>());
					var uitvoeringsResultaat = commando.GetType().GetMethod("Execute").Invoke(commando, new object[] { "" });
				}

				return instantie;
			} catch (Exception e) {
				// Weergeven van notificatie met boodschap kan als gebruiksvriendelijker alternatief
				// return null;

				throw new ApplicatieOverzichtViewModelException("Aanmaken van nieuw ViewModel is mislukt", e);
			}
		}

		private void WijzigActiefViewModel(IViewModel viewModel) {
			if(viewModel is null) {
				// Weergeven van notificatie met boodschap kan als gebruiksvriendelijker alternatief
				// return;
				throw new ApplicatieOverzichtViewModelException("Ontvangen IViewModel is null, er kan geen naam of type uit afgeleid worden.");
			}

			string viewNaam = viewModel.GetType().Name.Replace("ViewModel", "");
			if (!BeheerdeViewModels.Keys.Contains(viewNaam)) {
				BeheerdeViewModels.Add(viewNaam, (IViewModel)MaakNieuwViewModel(viewModel));
			}

			if(BeheerdeViewModels[viewNaam] is not null) {
				ActieveViewModel = BeheerdeViewModels.FirstOrDefault(vm => vm.Key == viewNaam).Value;
			} 
		}

		private void ResetViewModel(IViewModel viewModel) {
			BeheerdeViewModels[viewModel.GetType().Name.Replace("ViewModel", "")] = (IViewModel)MaakNieuwViewModel(viewModel);
		}

		#region Commands
		// Beheerfunctionaliteiten beschikbaar stellen
		public RelayCommand ResetViewModelCommand => new RelayCommand(
			p => ResetViewModel((IViewModel)p),
			p => p is IViewModel
		);

		public RelayCommand WijzigHuidigViewModel => new RelayCommand(
			p => WijzigActiefViewModel((IViewModel)p),
			p => p is IViewModel
		);
		#endregion
	}
}
