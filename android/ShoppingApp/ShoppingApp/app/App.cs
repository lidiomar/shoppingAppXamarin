using System;
using System.IO;
using Android.App;
using ShoppingApp.app.db;

namespace ShoppingApp.app
{
    public class App : Application
    {
        static AppDatabase database;

        public static AppDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AppDatabase();
                }
                return database;
            }
        }
    }
}
