using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Rebex.Net;

namespace BlueSheep
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayData : ContentPage
    {
        string filePath;
        string nameOfFile;

        public DisplayData(string SensorName)
        {
            InitializeComponent();

            TopLabel.Text = SensorName;
            if (SensorName == "DeviceOrientation")
            {
                nameOfFile = "Co" + "log.png"; //close enough
            }
            else if (SensorName == "Proximity")
            {
                nameOfFile = "Am" + "log.png";
            }
            else
            {
                nameOfFile = SensorName.Substring(0, 2) + "log.png";
            }

            filePath = Path.Combine(App.Logpath, (nameOfFile));

            Request_Fom_Server();
        }

        void Request_Fom_Server()
        {
            Rebex.Licensing.Key = App.RebexKey;
            Sftp client = new Sftp();
            client.Connect(App.hostname);
            client.Login(App.serverUsername, App.serverPassword);

            client.GetFile(nameOfFile, filePath);

            GraphImage.Source = filePath;

            client.Disconnect();
        }
    }
}