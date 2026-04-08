using Android.Graphics.Drawables;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace LavaJatoApp.MAUI.Controls;

public partial class BorderedEntry
{
    static partial void MapBordered(EntryHandler handler, BorderedEntry view)
    {
        Color? borderColor = Colors.Gray;

        if (global::Microsoft.Maui.Controls.Application.Current?.Resources.TryGetValue("CinzaNeblina",
                out object? resource) == true &&
            resource is Color colorFromResources)
            borderColor = colorFromResources;

        GradientDrawable gd = new();
        gd.SetStroke(2, borderColor.ToPlatform());
        gd.SetCornerRadius(6);

        handler.PlatformView.Background = gd;
    }
}
