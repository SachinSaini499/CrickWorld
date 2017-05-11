using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CrickWorld.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

      async  private void Button_OnClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new SignUp());
        }
    }
}
