using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiProjekt14D20251210.Models;

namespace MauiProjekt14D20251210.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection db;

        public DatabaseService(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Book>().Wait();
        }

        public Task<List<Book>> GetBooksAsync() =>
            db.Table<Book>().ToListAsync();

        public Task<int> AddBookAsync(Book book) =>
            db.InsertAsync(book);

        public Task<int> UpdateBookAsync(Book book) =>
            db.UpdateAsync(book);

        public Task<int> DeleteBookAsync(Book book) =>
            db.DeleteAsync(book);
    }
}
