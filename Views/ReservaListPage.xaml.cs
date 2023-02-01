namespace CFHerrera.Views;

using Microsoft.Maui.Controls;
using CFHerrera.Models;
using System.Collections.Generic;
public partial class ReservaListPage : ContentPage
{
	bool aux = false;
	public ReservaListPage()
	{
		InitializeComponent();
        List<Reserva> reserva = App.Repositorio.GetAllReservas();
        listareservas.ItemsSource = reserva;
        if (!reserva.Any())
        {
            mensajeVacio.IsVisible = true;
        }
        else
        {
            mensajeVacio.IsVisible = false;
        }
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ReservaItemPage));
    }


    public void buscarReserva(object sender, EventArgs e)
    {
        List<Reserva> reserva = App.Repositorio.GetReservasByName(reservabuscada.Text);
        listareservas.ItemsSource = reserva;
        if (!reserva.Any())
        {
            mensajeVacio.IsVisible = true;
        }
        else
        {
            mensajeVacio.IsVisible = false;
        }
        aux = true;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        List<Reserva> reserva = App.Repositorio.GetAllReservas();
        listareservas.ItemsSource = reserva;
        if (!reserva.Any())
        {
            mensajeVacio.IsVisible = true;
        }
        else
        {
            mensajeVacio.IsVisible = false;
        }
    }

    private void cambioTexto(object sender, TextChangedEventArgs e)
    {
        var newText = e.NewTextValue;
        if (string.IsNullOrWhiteSpace(newText))
        {
            borrarBtn.IsEnabled = false;
            borrarBtn.IsVisible = false;
            if (aux == true)
            {
                aux = false;
                List<Reserva> reserva = App.Repositorio.GetAllReservas();
                listareservas.ItemsSource = reserva;
                if (!reserva.Any())
                {
                    mensajeVacio.IsVisible = true;
                }
                else
                {
                    mensajeVacio.IsVisible = false;
                }
            }
        }
        else
        {
            borrarBtn.IsEnabled = true;
            borrarBtn.IsVisible = true;
            if (aux == true)
            {
                List<Reserva> reserva = App.Repositorio.GetReservasByName(reservabuscada.Text);
                listareservas.ItemsSource = reserva;
                if (!reserva.Any())
                {
                    mensajeVacio.IsVisible = true;
                }
                else
                {
                    mensajeVacio.IsVisible = false;
                }
            }
        }
    }


    private async void cambioSeleccion(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var reserva = (Models.Reserva)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(ReservaItemPage)}?{nameof(ReservaItemPage.reservaID)}={reserva.Id}");

            // Unselect the UI
            listareservas.SelectedItem = null;
        }
    }

    private void borrarBuscar(object sender, EventArgs e)
    {
        reservabuscada.Text = "";
    }

    private async void borrarLista(object sender, EventArgs e)
    {
        bool respuesta = await DisplayAlert("Alerta", "¿Estás seguro de que desea borrar todas las reservas de la lista? \n" +
            "Esta acción borrará todos los items de la base de datos y restaurará los Ids", "No", "Sí");
        if (!respuesta)
        {
            App.Repositorio.eliminarTodasReservas();
            List<Reserva> reserva = App.Repositorio.GetAllReservas();
            listareservas.ItemsSource = reserva;
            if (!reserva.Any())
            {
                mensajeVacio.IsVisible = true;
            }
            else
            {
                mensajeVacio.IsVisible = false;
            }
        }
        else
        {
            return;
        }
    }

    private void onPressed(object sender, EventArgs e)
    {
        botonAgregar.BackgroundColor = Color.FromArgb("#D52941");
    }

    private void onReleased(object sender, EventArgs e)
    {
        botonAgregar.BackgroundColor = Color.FromArgb("#512bd4");
    }
}