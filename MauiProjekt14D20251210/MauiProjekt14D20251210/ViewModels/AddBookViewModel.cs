using MauiProjekt14D20251210.Models;
using MauiProjekt14D20251210.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiProjekt14D20251210.ViewModels;

public class AddBookViewModel : BaseViewModel
{
    private readonly DatabaseService _database;

    public string Title { get; set; }
    public string Author { get; set; }

    public ICommand SaveCommand { get; }

    public AddBookViewModel(DatabaseService database)
    {
        _database = database;
        SaveCommand = new Command(async () =>
        {
            var book = new Book { Title = Title, Author = Author };
            await _database.AddBookAsync(book);
            await Shell.Current.GoToAsync("..");
        });
    }
}

