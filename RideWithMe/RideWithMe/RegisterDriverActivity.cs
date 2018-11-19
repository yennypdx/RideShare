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
            //sql-lite to insert data into tables
            

        }
        
        private void InsertDataAsDriver()
        {
            //to be a DRIVER MUST HAVE: firstname, lastname, email, passwd, phone, vehicle type, plate number
            //insertion to User table and Driver table.
            //copy the userId to Rider table and Driver table
            //const string connectionstring = @"Data Source = RideShareDB.sqlite; Version = 3;";

            //SQLiteConnection connection = new SQLiteConnection(connectionstring);
        }
    }
}