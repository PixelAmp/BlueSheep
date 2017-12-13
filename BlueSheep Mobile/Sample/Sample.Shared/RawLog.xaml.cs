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

        public RawLog(string Log)
        {
            InitializeComponent();

            nameOfFile = Log[0] + "log.txt";
            
            filePath = Path.Combine(App.Logpath, (nameOfFile));

            LogLabel.Text = Log;

            WriteLog(Log);

            SendLog(Log);

        }

        void SendLog(string Log)
        {
            Rebex.Licensing.Key = App.RebexKey;
            // create client, connect and log in
            Sftp client = new Sftp();
            client.Connect(App.hostname);
            client.Login(App.serverUsername, App.serverPassword);

            client.PutFile(filePath, nameOfFile);


            client.Disconnect();
        }

        void WriteLog(string Log)
        {
            using (var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(Log);
            }
        }
    }
}