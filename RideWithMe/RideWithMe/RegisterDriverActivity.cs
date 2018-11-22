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
            //to be a DRIVER MUST HAVE: firstname, lastname, email, passwd, phone, vehicle type, plate number
            //insertion to User table and Driver table.
            //copy the userId to Rider table and Driver table
            const string connectionstring =
                @"Data Source = C:\Users\Yenny Wright\Desktop\CST324 TermProject\RideShareDB.sqlite; Version = 3;";

            string fnameparam = FindViewById(Resource.Id.input_fname).ToString();
            string lnameparam = FindViewById(Resource.Id.input_lname).ToString();
            string emailparam = FindViewById(Resource.Id.input_emailreg).ToString();
            string passwdparam = FindViewById(Resource.Id.input_passreg).ToString();
            string phoneparam = FindViewById(Resource.Id.input_phone).ToString();
            string vtypeparam = FindViewById(Resource.Id.input_vtype).ToString();
            string plateparam = FindViewById(Resource.Id.input_plate).ToString();

            var queryInsertToUserTable = "INSERT INTO User (FirstName, LastName, LoginEmail, Passwd, PhoneNumber ) " +
                                         "VALUES ({fnameparam}, {lnameparam}, {emailparam}, {passwdparam}, {phoneparam})";
            var queryGetUserId = "SELECT UserId FROM User WHERE LoginEmail = {emailparam}";
            var queryInsertToDriverTable = "INSERT INTO Driver (UserId, VehicleType, LicensePlate) VALUES ({userId}, {vtypeparam}, {plateparam})";
            var connection = new SQLiteConnection(connectionstring);

            try
            {
                connection.Open();
                SQLiteCommand commandInsertUser = new SQLiteCommand(queryInsertToUserTable, connection);
                commandInsertUser.ExecuteNonQuery();
                SQLiteCommand commandGetId = new SQLiteCommand(queryGetUserId, connection);
                SQLiteCommand commandInsertDriver = new SQLiteCommand(queryInsertToDriverTable, connection);

                var userId = 0;
                var result = commandGetId.ExecuteReader();
                if (result.Read())
                {
                    userId = result.GetInt32(result.GetOrdinal("UserId"));
                }
                connection.Close();

                connection.Open();
                commandInsertDriver.ExecuteNonQuery();
                connection.Close();
            }
            catch (SQLiteException ex)
            {
                System.Diagnostics.Debug.WriteLine("SQLite Error.", ex.Message);
            }
        }
    }
}