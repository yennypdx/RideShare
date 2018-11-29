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
    public class Request
    {
        public int RequestId { get; set; }
        public int RiderId { get; set; }
        public int PaymentId { get; set; }
        public int LocationId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }       
    }
}