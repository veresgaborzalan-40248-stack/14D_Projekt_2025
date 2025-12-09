using MauiProjekt14D20251210.Models;
using MauiProjekt14D20251210.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiProjekt14D20251210.ViewModels;

[QueryProperty(nameof(Book), "Book")]
public class EditBookViewModel : BaseViewModel
{
    private readonly DatabaseService _database;

    private Book _book;
    public Book Book
    {
        get => _book;
        set
        {
            _book = value;
            Title = _book.Title;
            Author = _book.Author;
        }
    }

    private string _title;
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    private string _author;
    public string Author
    {
        get => _author;
        set => SetProperty(ref _author, value);
    }

    public ICommand SaveCommand { get; }
    public ICommand DeleteCommand { get; }

    public EditBookViewModel(DatabaseService database)
    {
        _database = database;

        SaveCommand = new Command(async () =>
        {
            Book.Title = Title;
            Book.Author = Author;
            await _database.UpdateBookAsync(Book);
            await Shell.Current.GoToAsync("..");
        });

        DeleteCommand = new Command(async () =>
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Törlés", "Biztosan törölni szeretnéd a könyvet?", "Igen", "Mégse");

            if (confirm)
            {
                await _database.DeleteBookAsync(Book);
                await Shell.Current.GoToAsync("..");
            }
        });
    }
}

