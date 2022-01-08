# MVVM patroon in WPF
Een simpele implementatie van het MVVM patroon in WPF. 

Maakt gebruik van een beherend View en ViewModel welke de basis vormt voor de overige Views & ViewModels.

De gebruiker kan, indien voorzien, rechtstreeks invloed uitoefenen op deze beherende "laag" om van weergegeven View te veranderen. 

Men kan overigens vanuit de Views en ViewModels die het beheert de commando's van de parent, het beherend paar, aanroepen, welke toe laat om ook via deze weg van View te veranderen en het ViewModel te beinvloeden.


## Repository status
Files dienen toegevoegd te worden aan de repository.


## De rol van App en diens codebehind
Deze Application staat ingesteld als startup object van het project.

De XAML van App, in `App.xaml`, bevat eventuele referenties naar Application.Resources, een voorbeeld hiervan is een MaterialDesign theme en zijn ResourceDictionaries.

Door middel van de codebehind, in `App.xaml.cs`, wordt het ApplicatieOverzicht geinstantieerd, met als datacontext een nieuwe instantie van het ApplicatieOverzichtViewModel.


## ApplicatieOverzicht & ApplicatieOverzichtViewModel
De Window ApplicatieOverzicht neemt als Window.Resources de verbanden op tussen de View en ViewModels die het beheert.

### Beherende functionaliteiten
In de Window kan men optioneel een menu definieren in de XAML met Binding naar de beherende commando's in het ViewModel.

Dit laat de gebruiker van de applicatie toe om de beherende functionaliteiten te benutten. (todo edit: In dit project is een menu gedefinieerd middels tabblad buttons.)


### Beheer principe
Indien gewenst kan er oneindig verder genest worden, dwz het ApplicatieOverzicht beheert een View en ViewModel welke op hun beurt andere Views en ViewModels beheren, dit om meerdere niveaus van beheer mogelijk te maken bij uitgebreide applicaties.

In dergelijk geval dient de afweging gemaakt te worden tussen het aanroepen van de beherende functionaliteiten vanuit descendants of het toevoegen van een nieuw niveau van beheer.


### ContentControl
Door gebruik te maken van een ContentControl in de Window met Binding op het HuidigeViewModel in ApplicatieOverzichtViewModel kan er overgeschakeld worden van View.

De commando's die aangeroepen worden veranderen het HuidigeViewModel, middels de voorgenoemde Binding en de verbanden in Window.Resources wordt het op deze manier mogelijk om de weergegeven View te wijzigen.


## Nuget packages
Dit project maakt gebruik van 2 packages, namelijk:

- MaterialDesign voor thematisering
- Fody + PropertyChanged.Fody 
- - Om bij ViewModels alle properties, ongeacht hun implementatie, PropertyChanged events te laten emitten (middels Bindings is de View dan steeds voorzien van de actuele waarde en is de code in het ViewModel overzichtelijker)

Mits enkele oppervlakkige wijzigingen kunnen deze afhankelijkheden weggelaten worden.
