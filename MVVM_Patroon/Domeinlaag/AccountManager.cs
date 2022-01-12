using Domeinlaag.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeinlaag {
	public class AccountManager {

		public List<Account> GeefAccounts() {
			return MockRepository.GeefAccounts();
		}
	}
}
