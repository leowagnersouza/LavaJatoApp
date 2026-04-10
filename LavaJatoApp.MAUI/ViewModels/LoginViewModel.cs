using CommunityToolkit.Mvvm.Input;
using LavaJatoApp.Application.Interfaces.Services;
using LavaJatoApp.MAUI.Navigation;

namespace LavaJatoApp.MAUI.ViewModels;

public partial class LoginViewModel(INavigationService navigationService) : BaseViewModel(navigationService)
{
    [RelayCommand]
    private Task Login()
    {
        return NavigationService.GoToRootAsync(AppRoutes.Home);
    }
}
