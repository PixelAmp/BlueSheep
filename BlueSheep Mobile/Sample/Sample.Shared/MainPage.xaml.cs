﻿using System;
using Xamarin.Forms;

namespace BlueSheep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
            var item = new LogItems();
            DisplayLog.Text = item.Accelerometer;
        }

        void GoToLogPage(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RawLog());
        }

        void GoToChartPage(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new DataRep());
        }
    }
}
