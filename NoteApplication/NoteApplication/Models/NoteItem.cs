using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApplication.Models
{
    public class NoteItem
    {
        public NoteItem()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }

        
    }
}
