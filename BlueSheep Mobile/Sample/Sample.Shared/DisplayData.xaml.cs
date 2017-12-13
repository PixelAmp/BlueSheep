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

            nameOfFile = SensorName[0] + "log.png";

            filePath = Path.Combine(App.Logpath, (nameOfFile));

            //LogLabel.Text = SensorName;

            Request_Fom_Server();
        }

        void Request_Fom_Server()
        {
            Rebex.Licensing.Key = App.RebexKey;
            //Create client, connect and log in
            Sftp client = new Sftp();
            client.Connect(App.hostname);
            client.Login(App.serverUsername, App.serverPassword);

            client.GetFile(nameOfFile, filePath);

            GraphImage.Source = filePath;

            client.Disconnect();

        }
    }
}