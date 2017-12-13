using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO; //read and write files

namespace BlueSheep
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RawLog : ContentPage
	{
        public RawLog(string Log)
        {
            InitializeComponent();
            
            LogLabel.Text = Log;
            SendLog(Log);
            WriteToFile(Log);
        }

        void SendLog(string Log)
        {
            SendLogToServer instance = new SendLogToServer();
            instance.Server_Send(Log);
        }

        void WriteToFile(string Log)
        {
            char Sensortype;
            Sensortype = Log[0];

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = Path.Combine(path, (Sensortype + "Log.txt"));

            using (var streamWriter = new StreamWriter(filename, true))
            {
                streamWriter.WriteLine(Log);
            }
        }
    }
}