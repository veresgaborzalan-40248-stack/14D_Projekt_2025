using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiProjekt14D20251210.Models;
using MauiProjekt14D20251210.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiProjekt14D20251210.Views;

namespace MauiProjekt14D20251210.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly DatabaseService _database;

    public ObservableCollection<Book> Books { get; } = new ObservableCollection<Book>();

    public ICommand LoadCommand { get; }
    public ICommand AddBookCommand { get; }

    public MainViewModel(DatabaseService database)
    {
        _database = database;

        LoadCommand = new Command(async () =>
        {
            Books.Clear();
            var list = await _database.GetBooksAsync();
            foreach (var book in list)
                Books.Add(book);
        });

        AddBookCommand = new Command(async () =>
            await Shell.Current.GoToAsync(nameof(AddBookPage)));
    }
}

