using CrickWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CrickWorld.Views
{
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
            //BindingContext = new UserDetails();
        }

    //async    private void Button_OnClicked(object sender, EventArgs e)
    //    {
    //        var userServices = new UserServices();
    //        UserDetails userDetail = BindingContext as UserDetails;
    //        await userServices.postUsersAsync(userDetail);
    //        // throw new NotImplementedException();
    //    }
    }
}
