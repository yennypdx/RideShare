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
    [Activity(Label = "RiderActivity")]
    public class RiderActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Rider);

            //Button btnSendRequest = FindViewById<Button>(Resource.Id.btn_sendriderRequest);
            //btnSendRequest.Click += SendRequestButton_Click;
        }

        private void SendRequestButton_Click(object sender, EventArgs e)
        {

        }
    }
}