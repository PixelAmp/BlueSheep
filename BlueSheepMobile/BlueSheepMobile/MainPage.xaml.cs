using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel; //needed for obsevable object

namespace BlueSheepMobile
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            PopulateListView();
        }

        //refresh table
        void Handle_Refreshing(object sender, System.EventArgs e)
        {
            // Do whatever refresh logic you want here

            // Remember you have to set IsRefreshing False to make spinny thing go away
            MainMenuListView.IsRefreshing = false;

        }

        private void PopulateListView()
        {
            var itemCollection = new ObservableCollection<MainMenuTemplate>();

            var BlueTooth = new MainMenuTemplate
            {
                Function = "BlueTooth",
                QuickInfo = "Collect data from BlueTooth Radio",
                MoreInfoText = "Enter more info here",
            };
            var Location = new MainMenuTemplate
            {
                Function = "Location",
                QuickInfo = "Track Phone's Location",
                MoreInfoText = "",
            };
            var Accele = new MainMenuTemplate
            {
                Function = "Accelerometer",
                QuickInfo = "Track phone's movement",
                MoreInfoText = "",
            };
            var AmbiLight = new MainMenuTemplate
            {
                Function = "Ambient Light Sensor",
                QuickInfo = "Track phone's exposure to light",
                MoreInfoText = "",
            };
            var Battery = new MainMenuTemplate
            {
                Function = "Battery Tracker",
                QuickInfo = "Track phone's battery usage",
                MoreInfoText = "",
            };

            itemCollection.Add(BlueTooth);
            itemCollection.Add(Location);
            itemCollection.Add(Accele);
            itemCollection.Add(AmbiLight);
            itemCollection.Add(Battery);

            MainMenuListView.ItemsSource = itemCollection;
        }

        //called when switch is toggled
        void Handle_SwitchToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            var userSwitch = (Switch)sender; //grabs the switch that called function
            var tab = (Grid)userSwitch.Parent; //grabs the parent of the switch, in this case the label

            var random = new Random(DateTime.Now.Millisecond);
            Color randomColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
           // tab.BackgroundColor = randomColor; //makes label random color
            userSwitch.BackgroundColor = randomColor; //makes button random color
        }

        //Go to a new page and send it's information
        void Handle_ContextMenuMoreButton(object sender, System.EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var PermissionItem = (MainMenuTemplate)menuItem.CommandParameter;
            //Navigation.PushAsync(new WebsiteMoreInfoPage(PermissionItem));
        }

        void Handle_To_Charts(object sender, System.EventArgs e)
        {

            Navigation.PushAsync(new MicroChartsDemo());
        }
    }
}
