using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiProjekt14D20251210.Models;

namespace MauiProjekt14D20251210.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _db;

    public DatabaseService(string dbPath)
    {
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Book>().Wait();
    }

    public Task<List<Book>> GetBooksAsync() => _db.Table<Book>().ToListAsync();
    public Task<int> AddBookAsync(Book book) => _db.InsertAsync(book);
    public Task<int> UpdateBookAsync(Book book) => _db.UpdateAsync(book);
    public Task<int> DeleteBookAsync(Book book) => _db.DeleteAsync(book);
}

