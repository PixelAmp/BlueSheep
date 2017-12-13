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
        string filename;

        public SensorViewModel(ISensor<TReading> sensor, string valueName, string title = null)
        {
            this.Title = title ?? sensor.GetType().Name.Replace("Impl", String.Empty);
            this.ValueName = valueName;
            this.ToggleText = sensor.IsAvailable ? "Start" : "Sensor Not Available";
            this.Value = "No Data";
            this.Log = ValueName;
            var item = new LogItems();
            filename = valueName + "Log.txt";


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

                    this.Time = DateTime.Now.ToString();
                }

                else
                {
                    this.ToggleText = "Start";
                    this.sensorSub.Dispose();
                    this.sensorSub = null;
                    this.Time = DateTime.Now.ToString();
                }
            });
        }
        
        public string Title { get; }
        public ICommand Toggle { get; }
        public string ValueName { get; }
        public string Value { get; set; }
        public string ToggleText { get; set; }
        public string Time { get; set; }
        public string Log { get; set; }



        //Sets value to reading and adds it to the log
        protected virtual void Update(TReading reading)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                this.Value = reading.ToString();
                this.Log += " #" + (DateTime.Now.ToString() + reading.ToString());                
            });
        }
    }
}
