using MauiProjekt14D20251210.Models;
using MauiProjekt14D20251210.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiProjekt14D20251210.ViewModels
{
    public class AddBookViewModel : BaseViewModel
    {
        private readonly DatabaseService db;

        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public ICommand SaveCommand { get; }

        public AddBookViewModel(DatabaseService databaseService)
        {
            db = databaseService;
            SaveCommand = new Command(async () => await Save());
        }

        private async Task Save()
        {
            await db.AddBookAsync(new Book
            {
                Title = Title,
                Author = Author,
                Year = Year
            });

            await Shell.Current.GoToAsync("..");
        }
    }

}
