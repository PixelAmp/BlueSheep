using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json; //use the Json Stuff
using System.Net.Http; //handle http requests
using System.IO;

namespace BlueSheep
{
    internal class SendLogToServer
    {
        public async void Server_Send(string SensorLog)
        {
            //create the item we want to send
            var item = new LogItems();
            item.Log = SensorLog;

            //set ip address to connect to
            //var uri = new Uri("http://34.208.179.48/index.py");
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
                    //await page.DisplayAlert("Unexpected Error", ex.Message, "OK");
                    return;
                }

                //if no errors, do something
                if (resItem.Success)
                {
                    //********************************************************************************
                    //put the code that resets the log File here
                    //********************************************************************************
                }
                else //else, display error
                {
                    //await page.DisplayAlert("Error", resItem.Response, "OK");
                    return;
                }
            }

            else
            { //Catch other errors
                //await page.DisplayAlert("Unexpected Error", response.ToString(), "OK");
                return;
            }

        } 
    }
}