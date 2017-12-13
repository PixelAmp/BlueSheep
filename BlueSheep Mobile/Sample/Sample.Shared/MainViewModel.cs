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
            this.Sensors = new List<ISensorViewModel>
            {
                new SensorViewModel<MotionReading>(CrossSensors.Accelerometer, "Ac"),
                new SensorViewModel<MotionReading>(CrossSensors.Gyroscope, "Gy"),
                new SensorViewModel<MotionReading>(CrossSensors.Magnetometer, "Ma"),
                new SensorViewModel<CompassReading>(CrossSensors.Compass, "Co"),
                new SensorViewModel<DeviceOrientation>(CrossSensors.DeviceOrientation, "De"),
                new SensorViewModel<double>(CrossSensors.AmbientLight, "Am"),
                new SensorViewModel<double>(CrossSensors.Barometer, "Ba"),
                new SensorViewModel<int>(CrossSensors.Pedometer, "Pe"),
                new SensorViewModel<bool>(CrossSensors.Proximity, "Pr")
            };
        }
    }
}
