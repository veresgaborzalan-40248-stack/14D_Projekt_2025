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
    public class EditBookViewModel : BaseViewModel
    {
        private readonly DatabaseService db;

        public Book Book { get; set; }

        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public EditBookViewModel(DatabaseService databaseService, Book book)
        {
            db = databaseService;
            Book = book;

            UpdateCommand = new Command(async () => await Update());
            DeleteCommand = new Command(async () => await Delete());
        }

        private async Task Update()
        {
            await db.UpdateBookAsync(Book);
            await Shell.Current.GoToAsync("..");
        }

        private async Task Delete()
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Megerősítés",
                "Biztosan törölni szeretné?",
                "Igen", "Mégsem");

            if (confirm)
            {
                await db.DeleteBookAsync(Book);
                await Shell.Current.GoToAsync("..");
            }
        }
    }

}
