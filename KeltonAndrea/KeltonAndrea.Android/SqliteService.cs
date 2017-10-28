using System;
using System.IO;
using Xamarin.Forms;
using KeltonAndrea.Droid;
using KeltonAndrea.DAO;

[assembly: Dependency(typeof(SqliteService))]
namespace KeltonAndrea.Droid
{
   
        public class SqliteService : ISQLite
        {
            public SQLite.Net.SQLiteConnection GetConnection()
            {
                var filename = "Usuarios.db3";
                var documentspath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var path = Path.Combine(documentspath, filename);

                var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                var connection = new SQLite.Net.SQLiteConnection(platform, path);
                return connection;
            }
        }
    }