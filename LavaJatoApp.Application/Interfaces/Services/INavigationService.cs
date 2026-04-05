namespace LavaJatoApp.Application.Interfaces.Services;

public interface INavigationService
{
	Task GoToAsync(string route);
	Task GoToRootAsync(string route);
}

