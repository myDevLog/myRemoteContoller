using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace myRemoteController
{
	public partial class MainPage : ContentPage
	{
		public IList<Page> MyControlViews { get; set; }

		public MainPage()
		{
			InitializeComponent();

			MyControlViews = new List<Page>() { new SpitfireControl("Spitfire", "SpitfireLogo.png") };
		}
	}
}
