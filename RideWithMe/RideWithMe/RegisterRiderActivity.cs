using System;
using System.Data.SQLite;
using Android.App;
using Android.OS;
using Android.Widget;

namespace RideWithMe
{
    [Activity(Label = "RegisterRiderActivity")]
    public class RegisterRiderActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegistrationRider);

            Button btnRSubmitData = FindViewById<Button>(Resource.Id.btn_reg);
            btnRSubmitData.Click += SubmitDataButton_Click;
        }

        private void SubmitDataButton_Click(object sender, EventArgs e)
        {
            //to be a RIDER MUST HAVE: firstname, lastname, email, passwd, phone 
            //insertion only to User table and copy the userId to Rider table 
            const string connectionstring =
                @"Data Source = C:\Users\Yenny Wright\Desktop\CST324 TermProject\RideShareDB.sqlite; Version = 3;";

            string fnameparam = FindViewById<EditText>(Resource.Id.input_fname).Text;
            string lnameparam = FindViewById<EditText>(Resource.Id.input_lname).Text;
            string emailparam = FindViewById<EditText>(Resource.Id.input_emailreg).Text;
            string passwdparam = FindViewById<EditText>(Resource.Id.input_passreg).Text;
            string phoneparam = FindViewById<EditText>(Resource.Id.input_phone).Text;

            var queryInsertToUserTable = "INSERT INTO User (FirstName, LastName, LoginEmail, Passwd, PhoneNumber) " +
                                         "VALUES ({fnameparam}, {lnameparam}, {emailparam}, {passwdparam}, {phoneparam})";
            var queryGetUserId = "SELECT UserId FROM User WHERE LoginEmail = {emailparam}";
            var queryInsertToRiderTable = "INSERT INTO Rider (UserId) VALUES ({userId})";
            try
            {
                var connection = new SQLiteConnection(connectionstring);
                connection.Open();
                SQLiteCommand commandInsertUser = new SQLiteCommand(queryInsertToUserTable, connection);
                commandInsertUser.ExecuteNonQuery();
                SQLiteCommand commandGetId = new SQLiteCommand(queryGetUserId, connection);
                SQLiteCommand commandInsertRider = new SQLiteCommand(queryInsertToRiderTable, connection);

                var userId = 0;
                var result = commandGetId.ExecuteReader();
                if (result.Read())
                {
                    userId = result.GetInt32(result.GetOrdinal("UserId"));
                }
                connection.Close();

                connection.Open();
                commandInsertRider.ExecuteNonQuery();
                connection.Close();
            }
            catch (SQLiteException ex)
            {
                System.Diagnostics.Debug.WriteLine("SQLite Error.", ex.Message);
            }
        }
    }
}