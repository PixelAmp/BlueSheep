using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json; //use the Json Stuff
using System.Net.Http; //handle http requests
using System.IO; //read and write files

namespace BlueSheep
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayLog : ContentPage
    {
        public DisplayLog(string DataType)
        {
            InitializeComponent();

            Request_Fom_Server(DataType);
        }

        async void Request_Fom_Server(string DataType)
        {
            //create the item we want to send
            var item = new DisplayItems();
            item.SensorType = DataType;

            //set ip address to connect to
            var uri = new Uri(App.URILocation);

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
                    return;
                }

                //if no errors, do something
                if (resItem.Success)
                {
                    //********************************************************************************
                    //put the code that makes recived image display
                    //********************************************************************************

                    //GraphImage.Source = resItem.Graph;    

                }

                else //else, display error
                {
                    await DisplayAlert("Error", resItem.Response, "OK");
                    return;
                }
            }

            else
            { //Catch other errors
                await DisplayAlert("Unexpected Error", response.ToString(), "OK");
                return;
            }
        }
    }
}