using LavaJatoApp.MAUI.ViewModels;
using Syncfusion.Maui.Kanban;

namespace LavaJatoApp.MAUI.Pages;

public partial class HomePage
{
    public HomePage(HomeViewModel vm)
        : base(vm)
    {
        InitializeComponent();
        KanbanBoard.AutoGenerateColumns = false;
        foreach (KanbanHeaderModel header in vm.Headers)
            KanbanBoard.Columns.Add(new KanbanColumn
            {
                Title = header.Title,
                Categories = [header.Category],
                Background = header.Background,
                AllowDrag = true,
                AllowDrop = true
            });
        KanbanBoard.ItemsSource = vm.Cards;
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        KanbanBoard.Columns.FirstOrDefault().IsExpanded = false;
    }
}
