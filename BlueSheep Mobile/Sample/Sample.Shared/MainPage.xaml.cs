using System;
using Xamarin.Forms;


namespace BlueSheep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }

        void GoToLogPage(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LogDisplay());
        }

    }
}
