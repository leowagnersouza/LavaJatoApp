using LavaJatoApp.Application.Interfaces.Services;

namespace LavaJatoApp.MAUI.ViewModels;

public class HomeViewModel : BaseViewModel
{
    public HomeViewModel(INavigationService navigationService)
        : base(navigationService)
    {
    }
}
