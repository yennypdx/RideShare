﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RideWithMe
{
    public class Driver
    {
        public int DriverId { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public string Eta { get; set; }
    }
}