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

        void GoToChartPage(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new DataRep());
        }

        void Log_To_Server(object sender, System.EventArgs e)
        {
            var listViewItem = (MenuItem)sender;
            string SensorName = (string)listViewItem.CommandParameter;

            Navigation.PushAsync(new RawLog(SensorName));
        }

        void Display_Data(object sender, System.EventArgs e)
        {
            var listViewItem = (MenuItem)sender;
            string DataType = (string)listViewItem.CommandParameter;

            Navigation.PushAsync(new DisplayData(DataType));
        }
    }
}
