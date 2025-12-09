using MauiProjekt14D20251210.Models;
using MauiProjekt14D20251210.ViewModels;

namespace MauiProjekt14D20251210.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as MainViewModel)?.LoadCommand.Execute(null);
    }

    private void OnBookSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Book selectedBook)
        {
            Shell.Current.GoToAsync(nameof(EditBookPage),
                new Dictionary<string, object> { { "Book", selectedBook } });
        }
    }
}
