using System.Collections.ObjectModel;
using LavaJatoApp.Application.Interfaces.Services;
using Syncfusion.Maui.Kanban;

namespace LavaJatoApp.MAUI.ViewModels;

public class HomeViewModel : BaseViewModel
{
    public ObservableCollection<KanbanModel> Cards
    {
        get;
        set;
    }

    public ObservableCollection<KanbanHeaderModel> Headers
    {
        get;
        set;
    }


    public HomeViewModel(INavigationService navigationService)
        : base(navigationService)
    {
        Cards =
        [
            new KanbanModel
            {
                ID = 1,
                Title = "FHY-3F79",
                Category = "Aguardando",
                Description = "09:40"
            },
            new KanbanModel
            {
                ID = 2,
                Title = "BRA-2E41",
                Category = "Aguardando",
                Description = "09:55"
            },
            new KanbanModel
            {
                ID = 3,
                Title = "QTM-8J26",
                Category = "Aguardando",
                Description = "10:10"
            },
            new KanbanModel
            {
                ID = 4,
                Title = "KLP-4N88",
                Category = "Aguardando",
                Description = "10:25"
            },
            new KanbanModel
            {
                ID = 5,
                Title = "XRV-7C13",
                Category = "Lavando",
                Description = "10:00"
            },
            new KanbanModel
            {
                ID = 6,
                Title = "MDS-1A57",
                Category = "Pronto",
                Description = "09:15"
            },
            new KanbanModel
            {
                ID = 7,
                Title = "ZNB-5K92",
                Category = "Pronto",
                Description = "09:30"
            }
        ];

        Headers =
        [
            new KanbanHeaderModel
            {
                Title = "Aguardando",
                Category = "Aguardando",
                Count = 4,
                Background = new SolidColorBrush(Color.FromArgb("#C6E2FF"))
            },
            new KanbanHeaderModel
            {
                Title = "Lavando",
                Category = "Lavando",
                Count = 4,
                Background = new SolidColorBrush(Color.FromArgb("#C6E2FF"))
            },
            new KanbanHeaderModel
            {
                Title = "Finalizando",
                Category = "Finalizando",
                Count = 4,
                Background = new SolidColorBrush(Color.FromArgb("#C6E2FF"))
            },
            new KanbanHeaderModel
            {
                Title = "Pronto",
                Category = "Pronto",
                Count = 4,
                Background = new SolidColorBrush(Color.FromArgb("#C6E2FF"))
            }
        ];
    }
}

public class KanbanHeaderModel
{
    public string Title
    {
        get;
        set;
    }

    public string Category
    {
        get;
        set;
    }

    public int Count
    {
        get;
        set;
    }

    public Brush? Background
    {
        get;
        set;
    }
}
