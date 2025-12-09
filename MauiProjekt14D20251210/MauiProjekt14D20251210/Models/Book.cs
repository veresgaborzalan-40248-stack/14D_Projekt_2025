using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiProjekt14D20251210.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200), NotNull]
        public string Title { get; set; }

        [MaxLength(150), NotNull]
        public string Author { get; set; }

        public int Year { get; set; }
    }
}
