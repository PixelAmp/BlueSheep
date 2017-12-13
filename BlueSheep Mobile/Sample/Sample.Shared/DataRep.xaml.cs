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
	public partial class DataRep : ContentPage
    {   
        //display the graphs of all the sensors
        string filePath;
        string nameOfFile;

        public DataRep()
        {
            InitializeComponent();
            StartRequest();
        }
        
        //void StartRequest(object sender, EventArgs e)
        void StartRequest()
        {
            Rebex.Licensing.Key = App.RebexKey;
            Sftp client = new Sftp();
            client.Connect(App.hostname);
            client.Login(App.serverUsername, App.serverPassword);

            //run though all of our sensors
            for (int i=0;i<8;i++)
            {
                Request_Fom_Server(client, i);
            }

            client.Disconnect();
        }

        void Request_Fom_Server(Sftp client, int count)
        {
            //I KNOW this is disgusting, but I don'y know of a better way to do it
            //it's 1:16 AM and the project is due in 12 hours. I DONT CARE ANYMORE

            switch (count)
            {
                case 0:
                    nameOfFile = "Ac" + "log.png";
                    break;
                case 1:
                    nameOfFile = "Gy" + "log.png";
                    break;
                case 2:
                    nameOfFile = "Ma" + "log.png";
                    break;
                case 3:
                    nameOfFile = "Co" + "log.png";
                    break;
                case 4:
                    nameOfFile = "Pe" + "log.png";
                    break;
                case 5:
                    nameOfFile = "Am" + "log.png";
                    break;
                case 6:
                    nameOfFile = "Ba" + "log.png";
                    break;
                case 7://not actually done RIP
                    //nameOfFile = "De" + "log.png";
                    nameOfFile = "Co" + "log.png"; //close enough
                    break;
                case 8://not actually done RIP
                    //nameOfFile = "Pr" + "log.png";
                    nameOfFile = "Am" + "log.png";
                    break;
            }

            filePath = Path.Combine(App.Logpath, (nameOfFile));
            
            client.GetFile(nameOfFile, filePath);

            switch (count)
            {
                case 0:
                    AcLabel.Text = "Accelerometer";
                    AcImage.Source = filePath;
                    break;
                case 1:
                    GyLabel.Text = "Gyroscope";
                    GyImage.Source = filePath;
                    break;
                case 2:
                    MaLabel.Text = "Magnetometer";
                    MaImage.Source = filePath;
                    break;
                case 3:
                    CoLabel.Text = "Compass";
                    CoImage.Source = filePath;
                    break;
                case 4:
                    DeLabel.Text = "Pedometer";
                    DeImage.Source = filePath;
                    break;
                case 5:
                    AmLabel.Text = "Ambient Light";
                    AmImage.Source = filePath;
                    break;
                case 6:
                    BaLabel.Text = "Barometer";
                    BaImage.Source = filePath;
                    break;
                case 7:
                    PeLabel.Text = "Device Orientation";
                    PeImage.Source = filePath;
                    break;

                
            }
            /*
            filePath.Substring(filePath.Length - 3);
            filePath += "txt";
            File.Delete(filePath); //delete file since it has already been sent
            */
        }
        
    }
}