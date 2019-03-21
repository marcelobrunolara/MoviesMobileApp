using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesMobileApp.Views.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DisconnectedView : ContentView
	{
		public DisconnectedView ()
		{
			InitializeComponent ();
		}
	}
}