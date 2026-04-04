using CommunityToolkit.Mvvm.Input;
using LavaJatoApp.MAUI.Navigation;

namespace LavaJatoApp.MAUI.ViewModels;

public partial class SplashIntroViewModel
{
    private readonly INavigationService _navigationService;

    public SplashIntroViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    private Task Prosseguir()
    {
        return _navigationService.GoToRootAsync(AppRoutes.Login);
    }
}
