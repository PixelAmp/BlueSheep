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
                await DisplayAlert("Error: UserEntry", "Please enter a Username", "OK");
                return;
            }

            //ask user before sending email
            await DisplayAlert("Message recived!", "Okay I've got the entire flock working on it! We'll get back to you as soon as we can!", "OK");

            await Navigation.PopAsync(); //removes login page from the stack
        }
	}
}