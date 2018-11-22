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
        bool cb_riderValue = false;
        bool cb_driverValue = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegOptions);

            CheckBox cb_rider = FindViewById<CheckBox>(Resource.Id.cb_rider);
            cb_rider.CheckedChange += (sender, args) =>
            {
                if (args.IsChecked)
                {
                    cb_riderValue = true;
                }
            };

            CheckBox cb_driver = FindViewById<CheckBox>(Resource.Id.cb_driver);
            cb_driver.CheckedChange += (sender, args) =>
            {
                if (args.IsChecked)
                {
                    cb_driverValue = true;
                }
            };

            Button btnNext = FindViewById<Button>(Resource.Id.btn_next);
            btnNext.Click += CheckOptions;
        }

        private void CheckOptions(object sender, EventArgs e)
        {
            if (cb_riderValue == true && cb_driverValue == false)
            {
                Intent intent1 = new Intent(this, typeof(RegisterRiderActivity));
                StartActivity(intent1);
            }
            else if (cb_riderValue == false && cb_driverValue == true)
            {
                Intent intent2 = new Intent(this, typeof(RegisterDriverActivity));
                StartActivity(intent2);
            }
            else if (cb_riderValue == true && cb_driverValue == true)
            {
                Intent intent3 = new Intent(this, typeof(RegisterDriverActivity));
                StartActivity(intent3);
            }
            else
            {
                //as default when none were chosen
                Intent intent4 = new Intent(this, typeof(RegisterRiderActivity));
                StartActivity(intent4);
            }
        }        
    }
}