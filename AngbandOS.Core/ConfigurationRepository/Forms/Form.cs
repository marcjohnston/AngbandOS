// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Forms;

[Serializable]
internal abstract class Form : IGetKey<string>
{
    protected readonly SaveGame SaveGame;

    protected Form(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
    protected abstract string[] WidgetNames { get; }
    public Widget[] Widgets { get; private set; }

    public string Key => GetType().Name;
    public string GetKey => Key;

    public void Bind()
    {
        List<Widget> widgetList = new List<Widget>();
        foreach (string widgetName in WidgetNames)
        {
            widgetList.Add(SaveGame.SingletonRepository.Widgets.Get(widgetName));
        }
        Widgets = widgetList.ToArray();
    }

    public string ToJson()
    {
        return "";
    }

    public void Invalidate()
    {
        // Clear the screen.
        SaveGame.MsgPrint(null);
        SaveGame.Screen.Clear();

        // Force all of the widgets to redraw.
        foreach (Widget widget in Widgets)
        {
            widget.Invalidate();
        }
    }
}
