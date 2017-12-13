using System;
using System.Reactive.Linq;
using System.Windows.Input;
using Plugin.Sensors;
using Xamarin.Forms;
using PropertyChanged;
using System.IO; //read and write files


namespace BlueSheep
{
    [ImplementPropertyChanged]
    public class SensorViewModel<TReading> : ISensorViewModel
    {
        IDisposable sensorSub;
        string filePath;

        public SensorViewModel(ISensor<TReading> sensor, string valueName, string title = null)
        {
            this.Title = title ?? sensor.GetType().Name.Replace("Impl", String.Empty);
            this.ValueName = valueName;
            this.ToggleText = sensor.IsAvailable ? "Start" : "Sensor Not Available";
            this.Value = "No Data";
            filePath = Path.Combine(App.Logpath, (Title.Substring(0, 2) + "log.txt"));


            this.Toggle = new Command(() =>
            {
                if (!sensor.IsAvailable)
                    return;

                if (this.sensorSub == null)
                {
                    this.ToggleText = "Stop";

                    this.sensorSub = sensor
                        .WhenReadingTaken()
                        .Sample(TimeSpan.FromSeconds(1))
                        .Subscribe(this.Update);
                }

                else
                {
                    this.ToggleText = "Start";
                    this.sensorSub.Dispose();
                    this.sensorSub = null;
                }
            });
        }
        
        public string Title { get; }
        public ICommand Toggle { get; }
        public string ValueName { get; }
        public string Value { get; set; }
        public string ToggleText { get; set; }



        //Sets value to reading and adds it to the log
        protected virtual void Update(TReading reading)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                this.Value = reading.ToString();

                using (var streamWriter = new StreamWriter(filePath, true))
                {
                    streamWriter.WriteLine( "#" + DateTime.Now.ToString() + reading.ToString());
                }
                //this.Log += " #" + (DateTime.Now.ToString() + reading.ToString());                
            });
        }
    }
}
