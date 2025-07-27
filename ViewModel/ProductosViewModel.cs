

using System.Collections.ObjectModel;
using System.ComponentModel;
using TiendaRopaApp.Models;

namespace TiendaRopaApp.ViewModels;

/// <summary>
/// ViewModel para la página de productos,
/// expone la lista de productos para la UI.
/// </summary>
public class ProductosViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Producto> Productos { get; } = new ObservableCollection<Producto>();

    public ProductosViewModel()
    {
        // Datos de prueba; luego se cargarán desde la base de datos
        Productos.Add(new Producto { ProductoId = 1, Nombre = "Remera Básica", Categoria = "Remeras", Color = "Blanco", Talle = "M", Stock = 10 });
        Productos.Add(new Producto { ProductoId = 2, Nombre = "Jean Azul", Categoria = "Pantalones", Color = "Azul", Talle = "L", Stock = 5 });
        Productos.Add(new Producto { ProductoId = 3, Nombre = "Gorra Negra", Categoria = "Accesorios", Color = "Negro", Talle = "Único", Stock = 20 });
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string nombrePropiedad) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
}
