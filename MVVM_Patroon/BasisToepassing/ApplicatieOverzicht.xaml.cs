using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BasisToepassing {
	public partial class ApplicatieOverzicht : Window {

        // bg + borderbrush todo
        // inactief: #FF673AB7 + #FF673AB7
        // actief: #FF8B6BC6  + Color.White

        // Door MVVM toe te passen is hier enkel code terug te vinden met betrekking tot weergave van de View

        private readonly List<Button> historischeTab = new();

        private readonly SolidColorBrush actiefTabblad = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF8B6BC6");
        private readonly SolidColorBrush inactiefTabblad = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");

        private void ActiveerTab_click(object sender, RoutedEventArgs e) {
            
            foreach (Button historicalBtn in historischeTab.ToList()) {
                historicalBtn.Background = inactiefTabblad;
                historicalBtn.BorderBrush = inactiefTabblad;
                historischeTab.Remove(historicalBtn);
            }

            Button btn = sender as Button;
            btn.Background = actiefTabblad;
            btn.BorderBrush = new SolidColorBrush(Color.FromScRgb(255, 255, 255, 255));

            historischeTab.Add(btn);
        }

        public ApplicatieOverzicht() {
            InitializeComponent();
            ActiveerTab_click(WelkomTab, null);
        }


    }
}
