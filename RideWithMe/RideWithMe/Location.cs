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
    public class Location
    {
        public int LocationId { get; set; }
        public string PickUpStreet { get; set; }
        public string PickUpCity { get; set; }
        public string DropOffStreet { get; set; }
        public string DropOffCity { get; set; }

    }
}