using System.Linq;
namespace LavaJatoApp.MAUI;
public partial class SplashIntroPage : ContentPage
{
    public SplashIntroPage()
    {
        InitializeComponent();
    }
    private void OnVamosLaClicked(object? sender, EventArgs e)
    {
        var window = Application.Current?.Windows.FirstOrDefault();
        if (window is not null)
        {
            window.Page = new AppShell();
        }
    }
}
