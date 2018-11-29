using Android.Content;
using Android.Database.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using Android.Database;

namespace RideWithMe
{
    public class RideWithMeDbHelper : SQLiteOpenHelper
    {
        private const string APP_DATABASENAME = "RideWithMe.db3";
        private const int APP_DATABASE_VERSION = 1;

        public RideWithMeDbHelper(Context ctx):
        base(ctx, APP_DATABASENAME, null, APP_DATABASE_VERSION)
        {
            throw new NotImplementedException();
        }
        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(@"CREATE TABLE IF NOT EXISTS User(
                            UserId  INT PRIMARY KEY AUTOINCREMENT,
                            FirstName   TEXT    NOT NULL,
                            LastName    TEXT    NOT NULL,
                            LoginEmail  TEXT    NOT NULL    UNIQUE,
                            Passwd      TEXT    NOT NULL,
                            PhoneNumber TEXT    NOT NULL)");

            db.ExecSQL(@"CREATE TABLE IF NOT EXISTS Rider(
                            RiderId INT PRIMARY KEY AUTOINCREMENT,
                            UserId  INT REFERENCES User(UserId))");

            db.ExecSQL(@"CREATE TABLE IF NOT EXISTS Driver(
                            DriverId    INT PRIMARY KEY AUTOINCREMENT,
                            UserId      INT REFERENCES User(UserId),
                            VehicleId   INT REFERENCES Vehicle(VehicleId),
                            Eta         TEXT    NULL)");

            db.ExecSQL(@"CREATE TABLE IF NOT EXISTS Admin(
                            AdminId INT PRIMARY KEY AUTOINCREMENT,
                            UserId  INT REFERENCES User(UserId))");

            db.ExecSQL(@"CREATE TABLE IF NOT EXISTS Vehicle(
                            VehicleId       INT PRIMARY KEY AUTOINCREMENT,
                            VehicleType     TEXT    NOT NULL,
                            LicensePlate    TEXT    NOT NULL)");

            db.ExecSQL(@"CREATE TABLE IF NOT EXISTS Location(
                            LocationId      INT PRIMARY KEY AUTOINCREMENT,
                            PickUpStreet    TEXT    NOT NULL,
                            PickUpCity      TEXT    NOT NULL,
                            DropOffStreet   TEXT    NOT NULL,
                            DropOffCity     TEXT    NOT NULL)");

            db.ExecSQL(@"CREATE TABLE IF NOT EXISTS Payment(
                            PaymentId   INT PRIMARY KEY AUTOINCREMENT,
                            UserId      INT REFERENCES User(UserId),
                            CardNumber  TEXT    NULL,
                            AmountToPay MONEY   NULL)");

            db.ExecSQL(@"CREATE TABLE IF NOT EXISTS Request(
                            RequestId   INT PRIMARY KEY AUTOINCREMENT,
                            RiderId     INT REFERENCES Rider(RiderId),
                            PaymentId   INT REFERENCES Payment(PaymentId),
                            LocationId  INT REFERENCES Location(LocationId),
                            Date        TEXT    NOT NULL,
                            Time        TEXT    NOT NULL)");

            //pre-load admin information
            db.ExecSQL("INSERT INTO User (FirstName, LastName, LoginEmail, Passwd, PhoneNumber) " +
                       "VALUES('Yenny', 'Purwanto', 'yp@mail.com', 'test123', '(503)544-5472')");

            db.ExecSQL("INSERT INTO User (FirstName, LastName, LoginEmail, Passwd, PhoneNumber) " +
                       "VALUES('Lucas', 'Cordova', 'lucas@mail.com', 'test456', '(503)567-0987')");
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS User");
            db.ExecSQL("DROP TABLE IF EXISTS Rider");
            db.ExecSQL("DROP TABLE IF EXISTS Driver");
            db.ExecSQL("DROP TABLE IF EXISTS Admin");
            db.ExecSQL("DROP TABLE IF EXISTS Request");
            OnCreate(db);
        }

        //------------------Methods for Admin-----------------------//
        public IList<User> GetAllUsers()
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ICursor cursor = db.Query("Users", new string[] {"UserId", "FirstName", "LastName",
                                        "LoginEmail", "PhoneNumber"}, null, null, null, null, null);
            var users = new List<User>();

            while (cursor.MoveToNext())
            {
                users.Add(new User
                {
                    UserId = cursor.GetInt(0),
                    FirstName = cursor.GetString(1),
                    LastName = cursor.GetString(2),
                    LoginEmail = cursor.GetString(3),
                    PhoneNumber = cursor.GetString(4)

                });
            }
            cursor.Close();
            db.Close();

            return users;
        }

        public IList<User> GetUserByFirstNameSearch(string firstNameToSearch)
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ICursor cursor = db.Query("Users", new string[] {"UserId", "FirstName", "LastName", "LoginEmail", "PhoneNumber"}, 
                                "upper(FirstName) LIKE?", new string[] { "%" + firstNameToSearch.ToUpper() + "%" }, 
                                null, null, null, null);
            var users = new List<User>();

            while (cursor.MoveToNext())
            {
                users.Add(new User
                {
                    UserId = cursor.GetInt(0),
                    FirstName = cursor.GetString(1),
                    LastName = cursor.GetString(2),
                    LoginEmail = cursor.GetString(3),
                    PhoneNumber = cursor.GetString(4)

                });
            }
            cursor.Close();
            db.Close();

            return users;
        }

        public IList<User> GetUserByLastNameSearch(string lastNameToSearch)
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ICursor cursor = db.Query("Users", new string[] { "UserId", "FirstName", "LastName", "LoginEmail", "PhoneNumber" },
                                    "upper(LastName) LIKE?", new string[] { "%" + lastNameToSearch.ToUpper() + "%" },
                                    null, null, null, null);
            var users = new List<User>();

            while (cursor.MoveToNext())
            {
                users.Add(new User
                {
                    UserId = cursor.GetInt(0),
                    FirstName = cursor.GetString(1),
                    LastName = cursor.GetString(2),
                    LoginEmail = cursor.GetString(3),
                    PhoneNumber = cursor.GetString(4)

                });
            }
            cursor.Close();
            db.Close();

            return users;
        }

        //------------------Methods for Rider-----------------------//
        public void AddNewUserAsRider(User riderInfo)
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ContentValues values = new ContentValues();

            values.Put("FirstName", riderInfo.FirstName);
            values.Put("LastName", riderInfo.LastName);
            values.Put("LoginEmail", riderInfo.LoginEmail);
            values.Put("Passwd", riderInfo.Passwd);
            values.Put("PhoneNumber", riderInfo.PhoneNumber);

        }

        public void SubmitRequest(Request inReq, Location inLoc)
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ContentValues values = new ContentValues();

            values.Put("Date", inReq.Date);
            values.Put("Time", inReq.Time);

            values.Put("PickUpStreet", inLoc.PickUpStreet);
            values.Put("PickUpCity", inLoc.PickUpCity);
            values.Put("DropOffStreet", inLoc.DropOffStreet);
            values.Put("DropOffCity", inLoc.DropOffCity);
        }

        public void MakePayment(Payment inPay)
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ContentValues values = new ContentValues();

            values.Put("PaymentId", inPay.PaymentId);
            values.Put("CardNumber", inPay.CardNumber);
            values.Put("AmountToPay", inPay.AmountToPay);
        }

        //------------------Methods for Driver-----------------------//
        public void AddNewUserAsDriver(User driverInfo1, Vehicle driverInfo2)
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ContentValues values = new ContentValues();

            values.Put("FirstName", driverInfo1.FirstName);
            values.Put("LastName", driverInfo1.LastName);
            values.Put("LoginEmail", driverInfo1.LoginEmail);
            values.Put("Passwd", driverInfo1.Passwd);
            values.Put("PhoneNumber", driverInfo1.PhoneNumber);

            values.Put("VehicleType", driverInfo2.VehicleType);
            values.Put("LicensePlate", driverInfo2.LicensePlate);
        }

        public void SendMessageToRider()
        {
            throw new NotImplementedException();
        }
    }
}