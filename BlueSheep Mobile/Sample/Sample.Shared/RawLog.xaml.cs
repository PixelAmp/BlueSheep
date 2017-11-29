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
		public RawLog ()
		{
			InitializeComponent ();

            ReadFile();

            
        }

        async private void ReadFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //string path = Environment.ExternalStorageDirectory;
            string filename = Path.Combine(path, "SensorData.txt");
            
            //read file
            if (File.Exists(filename))
            {
                using (var streamReader = new StreamReader(filename))
                {
                    string content = streamReader.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine(content);
                    LogLabel.Text = content;
                }
                return;
            }

            else
            {
                await DisplayAlert("Error: NoLog", "No log file available", "OK");
                return;
            }
        }
	}
}