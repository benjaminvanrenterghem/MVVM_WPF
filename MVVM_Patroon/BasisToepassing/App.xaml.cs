using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BasisToepassing {
	// Het ApplicatieOverzicht wordt voorzien van diens ViewModel als DataContext.
    // Indien gewenst kunnen parameters voor het ViewModel bij instantiering meegegeven worden.
    // De Window wordt weergegeven.
	public sealed partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            ApplicatieOverzicht applicatie = new ApplicatieOverzicht();
            applicatie.DataContext = new ApplicatieOverzichtViewModel();
            applicatie.Show();
        }
    }
}
