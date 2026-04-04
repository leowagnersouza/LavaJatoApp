namespace LavaJatoApp.MAUI.Navigation;
public interface INavigationService
{
	Task GoToAsync(string route);
	Task GoToRootAsync(string route);
}
