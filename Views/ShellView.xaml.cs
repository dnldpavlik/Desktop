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

namespace DonPavlik.Desktop.Views
{
	/// <summary>
	/// Interaction logic for ShellView.xaml
	/// </summary>
	public partial class ShellView
	{
		public ShellView()
		{
			InitializeComponent();
		}

		private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}
	}
}
