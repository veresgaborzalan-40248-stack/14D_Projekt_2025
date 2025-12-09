using MauiProjekt14D20251210.ViewModels;

namespace MauiProjekt14D20251210.Views;

public partial class AddBookPage : ContentPage
{
    public AddBookPage(AddBookViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
