using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

[assembly: XamlCompilation(XamlCompilationOptions.Skip)]

namespace BlueSheep
{
    public partial class App : Application
    {
        public static HttpClient client;
        public static string userUsername = null;
        public static string userPassword = null;
        public static string curDatabaseId = null;


        public App()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000; //256KB

            this.InitializeComponent();

			//this.MainPage = new NavigationPage(new LoginPage());
            
            //Skip Login and go to main sensors page
            this.MainPage = new NavigationPage(new MainPage());
        }
    }
}
