using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace LavaJatoApp.MAUI.Controls;

public partial class BorderedEntry
{
    static partial void MapBordered(EntryHandler handler, BorderedEntry view)
    {
        MauiTextField textField = handler.PlatformView;

        Color? borderColor = Colors.Gray;
        if (Microsoft.Maui.Controls.Application.Current?.Resources.TryGetValue("CinzaNeblina", out object? resource) ==
            true &&
            resource is Color colorFromResources)
            borderColor = colorFromResources;

        textField.Layer.BorderWidth = 1;
        textField.Layer.BorderColor = borderColor.ToPlatform().CGColor;
        textField.Layer.CornerRadius = 6;
        textField.Layer.MasksToBounds = true;
    }
}
