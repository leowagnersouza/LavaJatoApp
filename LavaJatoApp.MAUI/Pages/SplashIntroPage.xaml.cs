using LavaJatoApp.MAUI.ViewModels;

namespace LavaJatoApp.MAUI.Pages;

public partial class SplashIntroPage : ContentPage
{
    public SplashIntroPage(SplashIntroViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
