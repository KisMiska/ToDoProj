using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ToDoMauiApp.Service;
using ToDoMauiApp.Service.Interfaces;
using ToDoMauiApp.View;
using ToDoMauiApp.ViewModel;

namespace ToDoMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>().UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddHttpClient<IToDoService, ToDoService>();
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<AddToDoViewModel>();
		builder.Services.AddTransient<AddTodoPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
