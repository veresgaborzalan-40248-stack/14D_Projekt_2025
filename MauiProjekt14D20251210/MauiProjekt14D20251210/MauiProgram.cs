using MauiProjekt14D20251210.Services;
using MauiProjekt14D20251210.ViewModels;
using MauiProjekt14D20251210.Views;
using Microsoft.Extensions.Logging;

namespace MauiProjekt14D20251210
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "books.db3");

            builder.Services.AddSingleton(new DatabaseService(dbPath));

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AddBookPage>();
            builder.Services.AddTransient<EditBookPage>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<AddBookViewModel>();
            builder.Services.AddTransient<EditBookViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif      

            return builder.Build();


        }
    }
}
