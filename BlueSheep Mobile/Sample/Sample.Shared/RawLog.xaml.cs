using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO; //read and write files
using Rebex.Net;

namespace BlueSheep
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RawLog : ContentPage
	{
        string filePath;
        string nameOfFile;

        public RawLog(string SensorName)
        {
            InitializeComponent();

            SensorNameLabel.Text += SensorName;

            nameOfFile = SensorName.Substring(0, 2) + "log.txt";
            
            filePath = Path.Combine(App.Logpath, (nameOfFile));

            LogLabel.Text = SensorName;

            SendLog();

            ReadLogAndDelete();

        }

        void ReadLogAndDelete()
        {
            using (var streamReader = new StreamReader(filePath))
            {
                string content = streamReader.ReadToEnd();
                LogLabel.Text = content;
            }

            //File.Delete(filePath); //delete file since it has already been sent
        }

        void SendLog()
        {
            Rebex.Licensing.Key = App.RebexKey;
            //Create client, connect and log in
            Sftp client = new Sftp();
            client.Connect(App.hostname);
            client.Login(App.serverUsername, App.serverPassword);

            client.PutFile(filePath, nameOfFile);

            client.Disconnect();
        }

        
    }
}