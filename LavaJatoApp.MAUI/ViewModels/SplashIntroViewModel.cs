using CommunityToolkit.Mvvm.Input;
using LavaJatoApp.Application.Interfaces.Services;
using LavaJatoApp.MAUI.Navigation;

namespace LavaJatoApp.MAUI.ViewModels;

public partial class SplashIntroViewModel
    : BaseViewModel
{
    public SplashIntroViewModel(INavigationService navigationService)
        : base(navigationService)
    {
    }

    [RelayCommand]
    private Task Prosseguir()
    {
        return NavigationService.GoToRootAsync(AppRoutes.Login);
    }
}
