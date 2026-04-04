namespace LavaJatoApp.MAUI.Navigation;
public class ShellNavigationService : INavigationService
{
	public Task GoToAsync(string route)
	{
		return GetShell().GoToAsync(route);
	}
	public Task GoToRootAsync(string route)
	{
		return GetShell().GoToAsync($"//{route}");
	}
	private static Shell GetShell()
	{
		return Shell.Current ?? throw new InvalidOperationException("Shell navigation is not available before AppShell is loaded.");
	}
}
