using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiProjekt14D20251210.Models;
using MauiProjekt14D20251210.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiProjekt14D20251210.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly DatabaseService db;

        public ObservableCollection<Book> Books { get; set; } = new();

        public ICommand LoadCommand { get; }
        public ICommand AddBookCommand { get; }

        public MainViewModel(DatabaseService databaseService)
        {
            db = databaseService;

            LoadCommand = new Command(async () => await LoadBooks());
            AddBookCommand = new Command(async () =>
                await Shell.Current.GoToAsync("AddBookPage"));
        }

        public async Task LoadBooks()
        {
            Books.Clear();
            var list = await db.GetBooksAsync();
            foreach (var book in list) Books.Add(book);
        }
    }
}
