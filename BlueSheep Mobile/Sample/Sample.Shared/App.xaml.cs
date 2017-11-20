using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Skip)]

namespace BlueSheep
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

			this.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
