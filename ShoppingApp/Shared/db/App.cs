using ShoppingApp.app.db;

namespace Droid.app
{
    public class App
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
