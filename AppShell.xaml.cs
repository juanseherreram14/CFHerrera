namespace CFHerrera;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.CanchaItemPAge), typeof(Views.CanchaItemPAge));
		Routing.RegisterRoute(nameof(Views.CanchaListPage), typeof(Views.CanchaListPage));
        Routing.RegisterRoute(nameof(Views.ReservaItemPage), typeof(Views.ReservaItemPage));
        Routing.RegisterRoute(nameof(Views.ReservaListPage), typeof(Views.ReservaListPage));
    }
}
