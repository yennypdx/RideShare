using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace RideWithMe
{
    [Activity(Label = "RideWithMe", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            //REGISTER ME button
            Button btnRegister = FindViewById<Button>(Resource.Id.btn_reg);
            btnRegister.Click += RegisterButton_Click;
            //RIDER button

            //DRIVER button

            //ADMIN button

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Register);
        }

        private void RiderButton_Click(object sender, EventArgs e)
        {
            //SetContentView(Resource.Layout.RiderPage);
        }

        private void DriverButton_Click(object sender, EventArgs e)
        {
            //SetContentView(Resource.Layout.DriverPage);
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            //SetContentView(Resource.Layout.AdminPage);
        }
    }
}

