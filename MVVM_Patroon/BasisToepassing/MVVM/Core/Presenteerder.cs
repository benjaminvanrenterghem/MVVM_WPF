using System.Collections.Generic;
using System.ComponentModel;
using PropertyChanged;
using System.Runtime.CompilerServices;

/*
    Van deze abstracte klasse wordt overgeerfd door de ViewModels.
    Het centraliseert de implementatie van de interface INotifyPropertyChanged.

    Indien men er voor kiest om niet van de dependency Fody en PropertyChanged.Fody gebruik te maken
    zal men bij property setters gebruik kunnen maken van de Update functie om met 1 lijn code:
        - de waarde van het private veld gerelateerd aan de property te veranderen
        - een PropertyChanged event te emitten welke, in dit geval de Views die er binding op hebben, op de hoogte te stellen van veranderingen

    Indien men het pakket gebruikt zal er, mits overerving/implementatie van INotifyPropertyChanged, de properties van een klasse bij het compileren omgevormd worden zodoende dat zij het emitten van de PropertyChanged event altijd uitvoeren bij wijzigingen.
*/
namespace BasisToepassing.MVVM.Core {
    internal abstract class Presenteerder : INotifyPropertyChanged {
		public event PropertyChangedEventHandler? PropertyChanged;

		protected void Update<T>(ref T veld, T waarde, [CallerMemberName] string? propertyNaam = null) {
			if (EqualityComparer<T>.Default.Equals(veld, waarde)) return;

			veld = waarde;
			OnPropertyChanged(propertyNaam);
		}

		public void OnPropertyChanged([CallerMemberName] string? propertyNaam = null) {
			var handler = PropertyChanged;
			handler?.Invoke(this, new PropertyChangedEventArgs(propertyNaam));
		}
	}
}
