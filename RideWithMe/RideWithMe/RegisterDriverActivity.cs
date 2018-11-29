using System;
using System.Data.SQLite;

using Android.App;
using Android.OS;
using Android.Widget;

namespace RideWithMe
{
    [Activity(Label = "RegisterDriverActivity")]
    public class RegisterDriverActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegistrationDriver);

            Button btnRSubmitData = FindViewById<Button>(Resource.Id.btn_reg);
            btnRSubmitData.Click += SubmitDataButton_Click;
        }

        private void SubmitDataButton_Click(object sender, EventArgs e)
        {
           
        }
    }
}