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
	public partial class LogDisplay : ContentPage
	{
		public LogDisplay ()
		{
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //string path = Environment.ExternalStorageDirectory;
            string filename = Path.Combine(path, "SensorData.txt");


            InitializeComponent ();

            //read file
            using (var streamReader = new StreamReader(filename))
            {
                string content = streamReader.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(content);
                LogLabel.Text = content;
            }
        }



	}
}