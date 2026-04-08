using Microsoft.Maui.Handlers;

namespace LavaJatoApp.MAUI.Controls;

public partial class BorderedEntry : Entry
{
    public BorderedEntry()
    {
        EntryHandler.Mapper.AppendToMapping("Bordered", (handler, view) =>
        {
            if (handler is EntryHandler entryHandler && view is BorderedEntry borderedEntry)
                MapBordered(entryHandler, borderedEntry);
        });
    }

    static partial void MapBordered(EntryHandler handler, BorderedEntry view);
}
