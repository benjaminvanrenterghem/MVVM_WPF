using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasisToepassing.MVVM.Views {

	public partial class ProductenView : UserControl {
		public ProductenView() {
			InitializeComponent();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e) {
			var ctx = (ProductenViewModel)this.DataContext;
			Task.Run(() => ctx.BeginStartupRoutine.Execute(0));
		}
	}
}
