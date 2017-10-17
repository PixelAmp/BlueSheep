using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;


namespace BlueSheepMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MicroChartsDemo : ContentPage
	{
		public MicroChartsDemo ()
		{
			InitializeComponent ();
            ViewDidLoad();
        }

        public void ViewDidLoad()
        {
            base.OnAppearing();

            List<Entry> entries = new List<Entry>
            {
                new Entry(200)
                {
                    Label = "January",
                    ValueLabel = "200",
                    FillColor = SKColor.Parse("#266489")
                },
                new Entry(400)
                {
                    Label = "February",
                    ValueLabel = "400",
                    FillColor = SKColor.Parse("#68B9C0")
                },
                new Entry(-100)
                {
                    Label = "March",
                    ValueLabel = "-100",
                    FillColor = SKColor.Parse("#90D585")
                }
            };

            var chart = new BarChart() { Entries = entries };


            this.chartView.Chart = chart;
        }
    }
}