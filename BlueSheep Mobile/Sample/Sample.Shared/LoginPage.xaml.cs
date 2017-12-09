using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json; //use the Json Stuff
using System.Net.Http; //handle http requests

namespace BlueSheep
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async private void Login_Clicked_Basic(object sender, EventArgs e)
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
                //this is so that the user doesn't back into the login page and makes the permissions page the top page on the stack
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
        
        async void Login_Clicked(object sender, System.EventArgs e)
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

            //create the item we want to send
            var item = new ValidateUserItem();
            item.Username = Username_Entry.Text;
            item.Password = Password_Entry.Text;

            //set ip address to connect to
            var uri = new Uri("http://34.208.179.48/index.py");

            //serialize object and make it ready for sending over the internet
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json"); //StringContent contains http headers

            //wait for response, then handle it
            var response = await App.client.PostAsync(uri, content); //post

            if (response.IsSuccessStatusCode)
            { //success
                //get our JSON response and convert it to a ResponseItem object
                ResponseItem resItem = new ResponseItem();
                try
                {
                    resItem = JsonConvert.DeserializeObject<ResponseItem>(await response.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Unexpected Error", ex.Message, "OK");
                }

                //if no errors, do something
                if (resItem.Success)
                {
                    //login was successful, so store the successful login info for future use. 
                    //(these variables are global to the app)
                    //will use username for log file

                    App.userUsername = item.Username;
                    App.userPassword = item.Password;
 
                    //this is so that the user doesn't back into the login page and makes the permissions page the top page on the stack
                    Navigation.InsertPageBefore(new MainPage(), this); //inserts next page below the login page
                    await Navigation.PopAsync(); //delete's login page from the stack so you can't go back to it

                }
                else //else, display error
                {
                    await DisplayAlert("Error", resItem.Response, "OK");
                }
            }

            else
            { //Catch other errors
                await DisplayAlert("Unexpected Error", response.ToString(), "OK");
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
            await DisplayAlert("Only temporary", "This button will be removed in the final build, only here to avoid logging in every time", "OK");
            //this is so that the user doesn't back into the login page and makes the permissions page the top page on the stack
            Navigation.InsertPageBefore(new MainPage(), this); //inserts next page below the login page
            await Navigation.PopAsync(); //removes login page from the stack

        }
    }
}