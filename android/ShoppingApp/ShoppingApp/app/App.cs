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

        public static bool DataBaseCreated()
        {
            return File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDatabase.dbName));
        }
    }
}
