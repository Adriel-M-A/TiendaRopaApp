using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinRT.Interop;
using Microsoft.UI.Windowing;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TiendaRopaApp;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();

        // Hacer que el contenido se extienda al title bar (para Mica)
        this.ExtendsContentIntoTitleBar = true;
        this.SetTitleBar(NavView);

        // Establecer tamaño inicial con AppWindow API
        var hWnd = WindowNative.GetWindowHandle(this);
        WindowId winId = Win32Interop.GetWindowIdFromWindow(hWnd);
        AppWindow appWindow = AppWindow.GetFromWindowId(winId);
        appWindow.Resize(new Windows.Graphics.SizeInt32 { Width = 1200, Height = 700 });
    }

    private void NavView_Loaded(object sender, RoutedEventArgs e)
    {
        // Navegar inicialmente a InicioPage
        //ContentFrame.Navigate(typeof(Views.InicioPage));
        NavView.SelectedItem = NavView.MenuItems[0];
    }

    private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItemContainer is NavigationViewItem item && item.Tag is string tag)
        {
            var pageType = Type.GetType(tag);
            if (pageType != null && ContentFrame.CurrentSourcePageType != pageType)
            {
                ContentFrame.Navigate(pageType);
            }
        }
    }
}
