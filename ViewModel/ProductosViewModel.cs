namespace TiendaRopaApp.ViewModels;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TiendaRopaApp.Models;

public class ProductosViewModel : INotifyPropertyChanged
{
    // Colección original de productos
    public ObservableCollection<Producto> Productos { get; } = new();

    // Colección que se mostrará en la UI, filtrada
    public ObservableCollection<Producto> ProductosFiltrados { get; } = new();

    string textoFiltro;
    /// <summary>
    /// Texto que escribe el usuario para filtrar productos.
    /// </summary>
    public string TextoFiltro
    {
        get => textoFiltro;
        set
        {
            if (textoFiltro == value) return;
            textoFiltro = value;
            OnPropertyChanged(nameof(TextoFiltro));
            AplicarFiltro();
        }
    }

    public ProductosViewModel()
    {
        // Datos de prueba inicial
        Productos.Add(new Producto { ProductoId = 1, Nombre = "Remera Básica", Categoria = "Remeras", Color = "Blanco", Talle = "M", Stock = 10 });
        Productos.Add(new Producto { ProductoId = 2, Nombre = "Jean Azul", Categoria = "Pantalones", Color = "Azul", Talle = "L", Stock = 5 });
        Productos.Add(new Producto { ProductoId = 3, Nombre = "Gorra Negra", Categoria = "Accesorios", Color = "Negro", Talle = "Único", Stock = 20 });

        // Inicializar la lista filtrada con todos los productos
        AplicarFiltro();
    }

    /// <summary>
    /// Actualiza ProductosFiltrados según TextoFiltro.
    /// </summary>
    void AplicarFiltro()
    {
        ProductosFiltrados.Clear();

        var consulta = Productos.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(textoFiltro))
        {
            var filtro = textoFiltro.Trim().ToLower();
            consulta = consulta.Where(p =>
                p.Nombre.ToLower().Contains(filtro) ||
                p.Categoria.ToLower().Contains(filtro)
            );
        }

        foreach (var p in consulta)
            ProductosFiltrados.Add(p);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string nombrePropiedad) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
}
