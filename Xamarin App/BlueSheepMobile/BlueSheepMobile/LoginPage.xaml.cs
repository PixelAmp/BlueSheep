using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueSheepMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{

			InitializeComponent ();
            //NavigationPage.SetHasBackButton(this, false);//disables the back button since this is the top page, preventing user from exiting the app
            if (OnBackButtonPressed())
            {
                DisplayAlert("Alert", "Incorrect Username and/or Password", "OK");
                Username_Entry.Text = "";
                Password_Entry.Text = "";

            }
        }

      
        private void Handle_Login(object sender, EventArgs e)
        {
            if(Username_Entry.Text == "admin" && Password_Entry.Text == "password")
            {      
                //this is so that the user doesn't back into the login page and makes the permissions page the top page on the stack
                Navigation.InsertPageBefore(new PermissionsPage(), this); //inserts next page below the login page
                Navigation.PopAsync(); //delets login page from the stack
            }

            else
            {
                DisplayAlert("Alert", "Incorrect Username and/or Password", "OK");
                Username_Entry.Text = "";
                Password_Entry.Text = "";
            }
        }

    }
}