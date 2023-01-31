using CFHerrera.Data;

namespace CFHerrera;

public partial class App : Application
{
	public static CanchaFacilDB Repositorio { get; set; }
	public App(CanchaFacilDB repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		Repositorio = repo;
	}
}
