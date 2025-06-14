using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PO2_projekt.Data;
using PO2_projekt.Factories;
using PO2_projekt.ViewModels;
using Microsoft.Extensions.Configuration;

namespace PO2_projekt;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        DataTemplates.Add(new ViewLocator());
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        collection.AddDbContext<LibraryDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        collection.AddSingleton<MainViewModel>();
        collection.AddTransient<DashboardViewModel>();
        collection.AddTransient<AddItemViewModel>();
        collection.AddTransient<AddMemberViewModel>();
        collection.AddTransient<BorrowViewModel>();
        collection.AddTransient<ReturnViewModel>();

        collection.AddSingleton<Func<ApplicationPageNames, PageViewModel>>(x => name => name switch
        {
            ApplicationPageNames.Dashboard => x.GetService<DashboardViewModel>(),
            ApplicationPageNames.AddItem => x.GetService<AddItemViewModel>(),
            ApplicationPageNames.AddMember => x.GetService<AddMemberViewModel>(),
            ApplicationPageNames.Borrow => x.GetService<BorrowViewModel>(),
            ApplicationPageNames.Return => x.GetService<ReturnViewModel>(),
            _ => throw new InvalidOperationException(),
        });
        
        collection.AddSingleton<PageFactory>();
        
        var services = collection.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainView
            {
                DataContext = services.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}