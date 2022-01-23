using BasisToepassing.MVVM.Core;
using BasisToepassing.MVVM.Core.Interfaces;
using Domeinlaag;
using Domeinlaag.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasisToepassing.MVVM.Views {
	internal class ProductenViewModel : Presenteerder, IViewModel {
		public string Naam => "Producten";
        private ProductManager _productManager;
        private bool EersteRenderPlaatsgevonden;

        // Binding properties
        public ObservableCollection<Product> Producten { get; private set; }

        // Zie AccountViewModel voor info over StartupRoutine
        private void StartupRoutine() {
            if (!EersteRenderPlaatsgevonden) {
                _productManager = new ProductManager();
                Producten = new(_productManager.GeefProducten());

                EersteRenderPlaatsgevonden = true;
            }
        }

        public RelayCommand BeginStartupRoutine =>
            new(
                f => this.StartupRoutine(),
                param => param is not null
        );
    }
}
