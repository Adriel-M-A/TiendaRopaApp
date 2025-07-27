using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TiendaRopaApp.ViewModels;

namespace TiendaRopaApp.Views;

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

    private void NuevoProducto_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new ContentDialog
        {
            Title = "Próximamente",
            Content = "La funcionalidad para crear un nuevo producto estará disponible próximamente.",
            CloseButtonText = "Cerrar",
            XamlRoot = this.XamlRoot
        };
        _ = dialog.ShowAsync();
    }
}
