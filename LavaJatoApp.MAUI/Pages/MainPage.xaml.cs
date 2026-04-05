using LavaJatoApp.MAUI.ViewModels;

namespace LavaJatoApp.MAUI.Pages;

public partial class MainPage
{
    private int count = 0;

    public MainPage(MainViewModel vm)
        : base(vm)
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
