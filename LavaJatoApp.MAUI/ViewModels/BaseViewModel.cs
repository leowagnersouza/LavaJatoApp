using LavaJatoApp.Application.Interfaces.Services;

namespace LavaJatoApp.MAUI.ViewModels;

public abstract class BaseViewModel
{
    protected BaseViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }

    protected INavigationService NavigationService
    {
        get;
    }
}
