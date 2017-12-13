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
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        async void Submit_Clicked(object sender, System.EventArgs e)
        {
            if (User_Entry.Text == null || User_Entry.Text == "")
            { //if entry box was not touched (null) or is touched but empty ("")
                await DisplayAlert("Error: UserEntry", "Please enter a Username or Email", "OK");
                return;
            }

            //ask user before sending email
            var answer = await DisplayAlert("Forgot Password?", "Making sure, would you like us to send your password to the email or username provided?", "Yes", "No");
            if (answer == false) //user changed their mind
            {
                return;
            }


        }
	}
}