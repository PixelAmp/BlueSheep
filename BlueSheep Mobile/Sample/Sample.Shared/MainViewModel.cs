using System;
using System.Collections.Generic;
using Plugin.Sensors;

//Initialize sensors to be drawing data
namespace BlueSheep
{
    public class MainViewModel
    {
        public List<ISensorViewModel> Sensors { get; }

        public MainViewModel()
        {
            //acceleromiter letter used to be a 'G' but changed to an A
            //if broken this might be why
            this.Sensors = new List<ISensorViewModel>
            {
                new SensorViewModel<MotionReading>(CrossSensors.Accelerometer, "A"),
                new SensorViewModel<MotionReading>(CrossSensors.Gyroscope, "G"),
                new SensorViewModel<MotionReading>(CrossSensors.Magnetometer, "M"),
                new SensorViewModel<CompassReading>(CrossSensors.Compass, "D"),
                new SensorViewModel<DeviceOrientation>(CrossSensors.DeviceOrientation, "Position"),
                new SensorViewModel<double>(CrossSensors.AmbientLight, "Light"),
                new SensorViewModel<double>(CrossSensors.Barometer, "Pressure"),
                new SensorViewModel<int>(CrossSensors.Pedometer, "Steps"),
                new SensorViewModel<bool>(CrossSensors.Proximity, "Near")
            };
        }
    }
}
