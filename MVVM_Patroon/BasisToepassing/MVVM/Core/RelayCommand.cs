using System;
using System.Diagnostics;
using System.Windows.Input;

/*
    Wordt gebruikt in ViewModels om functionaliteiten beschikbaar te stellen aan de View.
    En dit middels Binding in de xaml element argumenten Command (en CommandParameter) naar een RelayCommand uit het ViewModel.
    Het centraliseert de implementatie van de interface ICommand.

    Bij constructie wordt een delegate meegegeven welke onder de voorwaarden van het 2de argument,
    het predicaat, pas uitgevoerd mag worden.
*/
namespace BasisToepassing.MVVM.Core {
    internal class RelayCommand : ICommand {

        readonly Action<object> _uittevoeren;
        readonly Predicate<object> _kanUitvoeren;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute) {
            if (execute == null) {
                throw new ArgumentNullException("Uit te voeren functie kan niet null zijn");
            }

            _uittevoeren = execute;
            _kanUitvoeren = canExecute;
        }

        // Wordt gebruikt om te bepalen of de delegate uitgevoerd mag worden
        [DebuggerStepThrough]
        public bool CanExecute(object parameters) {
            return _kanUitvoeren == null ? true : _kanUitvoeren(parameters);
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Wordt aangeroepen door de View indien CanExecute een positief resultaat geeft
        public void Execute(object parameters) {
            _uittevoeren(parameters);
        }

    }
}
