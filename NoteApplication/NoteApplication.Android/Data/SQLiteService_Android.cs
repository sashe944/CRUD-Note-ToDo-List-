using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NoteApplication.Data;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

namespace NoteApplication.Droid.Data
{
    public class SQLiteService_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
   
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            
            var plat = new SQLitePlatformAndroid();
            var conn = new SQLiteConnection(plat, path);
            
            return conn;
        }
    }
}