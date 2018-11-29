using System;
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
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleType { get; set; }
        public string LicensePlate { get; set; }
    }
}