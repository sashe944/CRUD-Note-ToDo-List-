using NoteApplication.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NoteApplication.Data
{
    public class NoteItemDatabase
    {
        	/// <summary>
		/// The locker strategy is used for dealing with mulit-threading.
		/// Put simply, we are preventing errors caused from manipulating
		/// the DB from multiple threads at the same time.
		/// </summary>
		readonly static object locker = new object ();

		/// <summary>
		/// The database.
		/// </summary>
		readonly SQLiteConnection database;

		/// <summary>
		/// Static Database instance
		/// </summary>
		static NoteItemDatabase instance;

		/// <summary>
        /// Initializes a new instance of the <see cref="TodoXaml.NoteItemDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		public NoteItemDatabase()
		{
			// DependencyService is a factory method for getting our instance
			// of the ISQLite implementation. This implementation is platform
			// specific and will change depending on our device.
			database = DependencyService.Get<ISQLite> ().GetConnection ();

			// A table is collection of things managed by the DB.
			// Our NoteItem is managed, so we create a table.
			database.CreateTable<NoteItem>();
		}

		/// <summary>
		/// Gets the database.
		/// </summary>
		/// <returns>The database.</returns>
		public static NoteItemDatabase GetDatabase(){
			if(instance == null)
				instance = new NoteItemDatabase();
			return instance;
		}


		// Below we define the rules our app will use for accessing NoteItems

		public IEnumerable<NoteItem> GetItems ()
		{
			lock (locker) {
				return (from i in database.Table<NoteItem>() select i).ToList();
			}
		}

		public IEnumerable<NoteItem> GetItemsNotDone ()
		{
			lock (locker) {
				return database.Query<NoteItem>("SELECT * FROM [NoteItem] WHERE [Done] = 0");
			}
		}

		public NoteItem GetItem (int id) 
		{
			lock (locker) {
				return database.Table<NoteItem>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int SaveItem (NoteItem item) 
		{
			lock (locker)
			{
			    if (item.ID == 0) 
                    return database.Insert(item);

			    database.Update(item);
			    return item.ID;
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker) {
				return database.Delete<NoteItem>(id);
			}
		}
	}
}
