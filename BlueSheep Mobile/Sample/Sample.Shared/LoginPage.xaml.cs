using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueSheep
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async private void Login_Clicked(object sender, EventArgs e)
        {
            if (Username_Entry.Text == null || Username_Entry.Text == "")
            { //if entry box was not touched (null) or is touched but empty ("")
                await DisplayAlert("Error", "Please enter a Username", "OK");
                return;
            }

            if (Password_Entry.Text == null || Password_Entry.Text == "")
            { //if entry box was not touched (null) or is touched but empty ("")
                await DisplayAlert("Error", "Please enter a Password", "OK");
                return;
            }

            if (Username_Entry.Text == "admin" && Password_Entry.Text == "password")
            {
                App.LoggedIn = true;
                //this is so that the user doesn't back into the login page and makes the permissions page the top page on the stack
                Navigation.InsertPageBefore(new MainPage(), this); //inserts next page below the login page
                await Navigation.PopAsync(); //removes login page from the stack
            }

            else if(Username_Entry.Text == App.userUsername && Password_Entry.Text == App.userPassword)
            {
                App.LoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this); //inserts next page below the login page
                await Navigation.PopAsync(); //removes login page from the stack

            }


            else
            {
                await DisplayAlert("Error: IncorrectPassword", "Incorrect username or password", "OK");
                Password_Entry.Text = "";
                return;
            }
        }
        

        async void NewAccount_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewAccountPage()); //goto the new account creation page
        }

        async void ForgotPassword_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage()); //goto the new password retrival page
        }

        async void Bypass_Login(object sender, System.EventArgs e)
        {
            var answer = await DisplayAlert("Are you sure? :'(", "If you log in this way, your data will be lumped in with the general and will be completely anonymous", "Yes", "No");
            if (answer == false) //user changed their mind
            {
                return;
            }
            else
            {
                Navigation.InsertPageBefore(new MainPage(), this); //inserts next page below the login page
                await Navigation.PopAsync(); //removes login page from the stack
            }

        }
    }
}