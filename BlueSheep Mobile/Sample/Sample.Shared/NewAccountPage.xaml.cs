using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueSheep
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewAccountPage : ContentPage
	{
		public NewAccountPage ()
		{
			InitializeComponent ();
		}

        async private void Sign_up_command(object sender, EventArgs e)
        {
            if (Username_Entry.Text == null || Username_Entry.Text == "")
            { //if entry box was not touched (null) or is touched but empty ("")
                await DisplayAlert("Error: Username", "Please enter a Username", "OK");
                return;
            }

            if (Password_Entry.Text == null || Password_Entry.Text == "")
            { //if entry box was not touched (null) or is touched but empty ("")
                await DisplayAlert("Error: Password", "Please enter a Password", "OK");
                return;
            }
            
            await DisplayAlert("Account Created!", "Please log in", "OK");
            App.userUsername = Username_Entry.Text;
            App.userPassword = Password_Entry.Text;
            await Navigation.PopAsync(); //removes login page from the stack
        }
    }
}