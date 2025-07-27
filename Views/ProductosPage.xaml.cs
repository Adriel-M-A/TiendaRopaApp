
using Microsoft.UI.Xaml.Controls;
using TiendaRopaApp.ViewModels;

namespace TiendaRopaApp.Views;

/// <summary>
/// P�gina para gestionar el listado de productos.
/// </summary>
public sealed partial class ProductosPage : Page
{
    public ProductosViewModel ViewModel
    {
        get;
    }

    public ProductosPage()
    {
        this.InitializeComponent();
        ViewModel = new ProductosViewModel();
        this.DataContext = ViewModel;
    }
}
