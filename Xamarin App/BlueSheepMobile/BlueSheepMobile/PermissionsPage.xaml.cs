using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel; //needed for obsevable object

namespace BlueSheepMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PermissionsPage : ContentPage
	{
		public PermissionsPage ()
		{
			InitializeComponent ();
            PopulateListView();
        }

        //refresh table (does't do anything right now, but it's here in case we do need it to do something)
        void Handle_Refreshing(object sender, System.EventArgs e)
        {
            //Do whatever refresh logic you want here

            //Set IsRefreshing False to make spinny thing go away
            PermissionsListView.IsRefreshing = false;

        }

        private void PopulateListView()
        {
            var itemCollection = new ObservableCollection<PermissionTabTemplate>();

            var BlueTooth = new PermissionTabTemplate
            {
                Function = "Bluetooth",
                QuickInfo = "Collect data from BlueTooth Radio",
                MoreInfoText = "Enter more info here",
            };
            var ReadSMS = new PermissionTabTemplate
            {
                Function = "Read SMS",
                QuickInfo = "Allow phone to read incomming SMS messages",
                MoreInfoText = "",
            };
            var Location = new PermissionTabTemplate
            {
                Function = "Location",
                QuickInfo = "Track Phone's Location",
                MoreInfoText = "",
            };
            var RecordAudio = new PermissionTabTemplate
            {
                Function = "Record Audio",
                QuickInfo = "Allow application to record audio",
                MoreInfoText = "",
            };
            var PersistentActivity = new PermissionTabTemplate
            {
                Function = "PersistentActivity",
                QuickInfo = "Alow application to run in the background",
                MoreInfoText = "",
            };
            var Accele = new PermissionTabTemplate
            {
                Function = "Accelerometer",
                QuickInfo = "Track phone's movement",
                MoreInfoText = "",
            };
            var AmbiLight = new PermissionTabTemplate
            {
                Function = "Ambient Light Sensor",
                QuickInfo = "Track phone's exposure to light",
                MoreInfoText = "",
            };
            var Battery = new PermissionTabTemplate
            {
                Function = "Battery Tracker",
                QuickInfo = "Track phone's battery usage",
                MoreInfoText = "",
            };
            var WifiState = new PermissionTabTemplate
            {
                Function = "Wifi State",
                QuickInfo = "Track phone's wifi connection",
                MoreInfoText = "",
            };
            var NetworkState = new PermissionTabTemplate
            {
                Function = "Network State",
                QuickInfo = "Track phone's Mobile network state",
                MoreInfoText = "",
            };
            
            itemCollection.Add(BlueTooth);
            itemCollection.Add(ReadSMS);
            itemCollection.Add(Location);
            itemCollection.Add(RecordAudio);
            itemCollection.Add(PersistentActivity);
            itemCollection.Add(Accele);
            itemCollection.Add(AmbiLight);
            itemCollection.Add(Battery);
            itemCollection.Add(WifiState);
            itemCollection.Add(NetworkState);

            PermissionsListView.ItemsSource = itemCollection;
        }

        //called when switch is toggled
        void Handle_SwitchToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            var userSwitch = (Switch)sender; //grabs the switch that called function
            var tab = (Grid)userSwitch.Parent; //grabs the parent of the switch, in this case the label


            //changes colors
            var random = new Random(DateTime.Now.Millisecond);
            Color randomColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
            // tab.BackgroundColor = randomColor; //makes label random color
            userSwitch.BackgroundColor = randomColor; //makes button random color
        }


    }
}