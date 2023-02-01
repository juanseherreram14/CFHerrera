
using CFHerrera.Models;

using SQLite;
namespace CFHerrera.Views;


[QueryProperty(nameof(reservaID), nameof(reservaID))]
public partial class ReservaItemPage : ContentPage
{
    public List<Cancha> canchas = App.Repositorio.GetAllCanchas();
  
    Reserva reserva = new Reserva();
	Reserva aux = new Reserva();
 
    int cancha;
   

    public int reservaID
    {
        set { cargarReserva(value); }
    }
    public ReservaItemPage()
	{
		InitializeComponent();
       pickerCancha.ItemsSource = canchas;
      cancha = pickerCancha.SelectedIndex;
	}
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (BindingContext == null)
        {
            
            reserva.Name = nombre.Text;
            reserva.Fecha = fecha.Date;
            reserva.Jugadores = num.SelectedIndex;
            reserva.Cancha = canchas[cancha];
            int error = App.Repositorio.AddNewReserva(reserva);
            if (error == 404)
            {
                await DisplayAlert("Alerta", "La reserva no se pudo ingresar debido a que su nombre ya existe", "OK");
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }

        }
        else
        {
            App.Repositorio.actualizarReserva(aux.Id, aux.Name, aux.Fecha, aux.Jugadores, aux.Cancha);
            await Shell.Current.GoToAsync("..");
        }
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }


    private void cargarReserva(int id)
    {
        Models.Reserva reserva = new Models.Reserva();
        reserva = App.Repositorio.GetReservaById(id);
        aux = reserva;
        BindingContext = reserva;
    }

    private async void eliminarReserva(object sender, EventArgs e)
    {
        App.Repositorio.eliminarReserva(aux.Id);
        await Shell.Current.GoToAsync("..");
    }

    
}