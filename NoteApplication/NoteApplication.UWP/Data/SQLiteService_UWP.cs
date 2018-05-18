using NoteApplication.Data;
using NoteApplication.UWP.Data;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteService_UWP))]
namespace NoteApplication.UWP.Data
{
    public class SQLiteService_UWP : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "UWP_DB.db3";
            string documentsPath = ApplicationData.Current.LocalFolder.Path;
            var fullName = Path.Combine(documentsPath, dbName);
            var platform = new SQLitePlatformWinRT();

            if (!File.Exists(fullName))
                File.Create(fullName);

            return new SQLiteConnection(platform, fullName);
        }
    }
}
