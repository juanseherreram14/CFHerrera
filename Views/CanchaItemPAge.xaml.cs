using CFHerrera.Models;
using CFHerrera.Views;

namespace CFHerrera.Views;
using SQLite;

[QueryProperty(nameof(canchaID), nameof(canchaID))]
public partial class CanchaItemPAge : ContentPage
{
    Cancha cancha = new Cancha();
    Cancha aux = new Cancha();
    

    public int canchaID
    {
        set { cargarCancha(value); }
    }
    public CanchaItemPAge()
	{
		InitializeComponent();
	}

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (BindingContext == null)
        {
            cancha.Name = nombrecancha.Text;
            cancha.Deporte = deportecancha.Text;
            cancha.Ciudad= ciudadcancha.Text;
            int error = App.Repositorio.AddNewCancha(cancha);
            if (error == 404)
            {
                await DisplayAlert("Alerta", "La cancha no se pudo ingresar debido a que su nombre ya existe", "OK");
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }

        }
        else
        {
            App.Repositorio.actualizarCancha(aux.Id, aux.Name, aux.Deporte, aux.Ciudad);
            await Shell.Current.GoToAsync("..");
        }
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }


    private void cargarCancha(int id)
    {
        Models.Cancha cancha = new Models.Cancha();
        cancha = App.Repositorio.GetById(id);
        aux = cancha;
        BindingContext = cancha;
    }

    private async void eliminarCancha(object sender, EventArgs e)
    {
        App.Repositorio.eliminarCancha(aux.Id);
        await Shell.Current.GoToAsync("..");
    }
}