using LavaJatoApp.MAUI.ViewModels;

namespace LavaJatoApp.MAUI.Pages;

public partial class DashboardPage
{
    public DashboardPage(DashboardViewModel vm)
        : base(vm)
    {
        InitializeComponent();
    }
}
