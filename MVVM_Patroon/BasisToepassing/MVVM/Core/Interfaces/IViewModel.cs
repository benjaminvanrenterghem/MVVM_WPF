
// Door ViewModels te identificeren wordt omgang vereenvoudigd in het ApplicatieOverzichtViewModel,
// algemene additionele vereisten voor een ViewModel kunnen hier gedefinieerd worden.
namespace BasisToepassing.MVVM.Core.Interfaces {
	internal interface IViewModel {
		string Naam { get; }
	}
}
