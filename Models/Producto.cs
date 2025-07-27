
namespace TiendaRopaApp.Models;

/// <summary>
/// Representa un producto de la tienda de ropa,
/// con sus atributos básicos.
/// </summary>
public class Producto
{
    public int ProductoId
    {
        get; set;
    }
    public required string Nombre
    {
        get; set;
    }
    public required string Categoria
    {
        get; set;
    }
    public required string Color
    {
        get; set;
    }
    public required string Talle
    {
        get; set;
    }
    public int Stock
    {
        get; set;
    }

    /// <summary>
    /// Propiedad calculada para mostrar Color y Talle juntos.
    /// </summary>
    public string ColorTalle => $"{Color} / {Talle}";
}
