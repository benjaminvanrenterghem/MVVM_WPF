using BasisToepassing.MVVM.Core;
using BasisToepassing.MVVM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasisToepassing.MVVM.Views {
	internal class InstellingenViewModel : Presenteerder, IViewModel {
		public string Naam => "Instellingen";
	}
}
