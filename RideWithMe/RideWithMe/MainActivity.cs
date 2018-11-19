using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace RideWithMe
{
    [Activity(Label = "RideWithMe", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Button btnRegister = FindViewById<Button>(Resource.Id.btn_regme);
            btnRegister.Click += RegisterMeButton_Click;
            
            Button btnRider = FindViewById<Button>(Resource.Id.btn_rider);
            btnRider.Click += RiderButton_Click;
           
            Button btnDriver = FindViewById<Button>(Resource.Id.btn_driver);
            btnDriver.Click += DriverButton_Click;
            
            Button btnAdmin = FindViewById<Button>(Resource.Id.btn_admin);
            btnAdmin.Click += AdminButton_Click;
        }

        private void RegisterMeButton_Click(object sender, EventArgs e)
        {
            Intent intent1 = new Intent(this, typeof(RegOptionsActivity));
            StartActivity(intent1);
        }

        private void RiderButton_Click(object sender, EventArgs e)
        {
            Intent intent2 = new Intent(this, typeof(RiderActivity));
            StartActivity(intent2);
        }

        private void DriverButton_Click(object sender, EventArgs e)
        {
            Intent intent3 = new Intent(this, typeof(DriverActivity));
            StartActivity(intent3);
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            Intent intent4 = new Intent(this, typeof(AdminActivity));
            StartActivity(intent4);
        }
    }
}

