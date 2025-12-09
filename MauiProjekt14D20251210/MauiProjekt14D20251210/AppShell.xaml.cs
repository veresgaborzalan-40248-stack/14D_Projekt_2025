using MauiProjekt14D20251210.Views;

namespace MauiProjekt14D20251210;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AddBookPage), typeof(AddBookPage));
        Routing.RegisterRoute(nameof(EditBookPage), typeof(EditBookPage));
    }
}

