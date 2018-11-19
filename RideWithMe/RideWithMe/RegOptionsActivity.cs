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
    [Activity(Label = "RegOptionsActivity")]
    public class RegOptionsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegOptions);

            bool cb_riderValue = false;
            CheckBox cb_rider = FindViewById<CheckBox>(Resource.Id.cb_rider);
            cb_rider.CheckedChange += (sender, args) =>
            {
                if (!args.IsChecked)
                {
                    cb_riderValue = true;
                }
            };

            bool cb_driverValue = false;
            CheckBox cb_driver = FindViewById<CheckBox>(Resource.Id.cb_driver);
            cb_driver.CheckedChange += (sender, args) =>
            {
                if (!args.IsChecked)
                {
                    cb_driverValue = true;
                }
            };

            Button btnNext = FindViewById<Button>(Resource.Id.btn_next);
            if (cb_riderValue == true)
            {
                btnNext.Click += NextToRegRider;
            }
            else if (cb_driverValue == true)
            {
                btnNext.Click += NextToRegDriver;
            }
            else
            {
                btnNext.Click += NextToRegDriver;
            }
        }

        private void NextToRegDriver(object sender, EventArgs e)
        {
            Intent intent1 = new Intent(this, typeof(RegisterDriverActivity));
            StartActivity(intent1);
        }

        private void NextToRegRider(object sender, EventArgs e)
        {
            Intent intent2 = new Intent(this, typeof(RegisterRiderActivity));
            StartActivity(intent2);
        }
    }
}