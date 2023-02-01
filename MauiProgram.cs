using CFHerrera.Data;

namespace CFHerrera;

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
        string dbPath = FileAccessHelper.GetLocalFilePath("cancha.db3");
        builder.Services.AddSingleton<CanchaFacilDB>(s => ActivatorUtilities.CreateInstance<CanchaFacilDB>(s, dbPath));

        return builder.Build();
	}
}
