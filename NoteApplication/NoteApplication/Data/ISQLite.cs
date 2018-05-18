using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApplication.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
