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
        //public const string URILocation = "http://54.71.127.218/index.py";
        public const string URILocation = "http://54.71.127.218/index.py";
        public static string userUsername;
        public static string userPassword;
        public static string curDatabaseId;
        public static bool LoggedIn = false;
        public static bool Resetlog = false;

        public const string hostname = "35.160.19.120";
        public const string serverUsername = "client";
        public const string serverPassword = "yyV;'P^VzuR4e&7?wbd8";
        public const string RebexKey = "==AiYZCltZiMK6Rzn4UGFeg8KUnHs/86tdqzS6M7z1XuPk==";
        public static string Logpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        public App()
        {
            this.InitializeComponent();

            if (LoggedIn)
            {
                //Skip Login and go to main sensors page
                this.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                //
                this.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
