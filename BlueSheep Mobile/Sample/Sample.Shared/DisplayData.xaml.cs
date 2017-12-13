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
    public partial class DisplayData : ContentPage
    {
        public DisplayData(string DataType)
        {
            InitializeComponent();

            Request_Fom_Server(DataType);
        }

        void Request_Fom_Server(string DataType)
        {
           
        }
    }
}