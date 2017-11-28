using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json; //use the Json Stuff
using System.Net.Http; //handle http requests

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
                        return;

                    //create the item we want to send
                    var item = new ForgotPasswordItem();
                    item.Username = User_Entry.Text;

                    //set ip address to connect to
                    var uri = new Uri(" "/*"http://54.193.30.236/index.py"*/);

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
                    await DisplayAlert("Email Sent", resItem.Response, "OK");
                }

                else //else, display error
                {
                    await DisplayAlert("Error", resItem.Response, "OK");
                }
            }

            else
            { //catches errors in case it breaks
                await DisplayAlert("Unexpected Error", response.ToString(), "OK");
                return;
            }

        }
	}
}