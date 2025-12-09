using MauiProjekt14D20251210.ViewModels;
using MauiProjekt14D20251210.Models;

namespace MauiProjekt14D20251210.Views;

public partial class EditBookPage : ContentPage
{
    public EditBookPage(EditBookViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

