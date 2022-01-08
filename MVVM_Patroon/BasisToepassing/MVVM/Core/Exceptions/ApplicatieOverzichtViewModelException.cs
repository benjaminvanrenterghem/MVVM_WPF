using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasisToepassing.MVVM.Core.Exceptions {
	internal class ApplicatieOverzichtViewModelException : Exception {
		public ApplicatieOverzichtViewModelException(string message) : base(message) {
		}

		public ApplicatieOverzichtViewModelException(string message, Exception innerException) : base(message, innerException) {
		}
	}
}
