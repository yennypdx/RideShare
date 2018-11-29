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
    public class Payment
    {
        public int PaymentId { get; set; }
        public string CardNumber { get; set; }
        public double AmountToPay { get; set; }
    }
}