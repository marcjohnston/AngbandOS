// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Forms;

[Serializable]
internal abstract class Form : IGetKey
{
    protected readonly Game Game;

    protected Form(Game game)
    {
        Game = game;
    }
    protected abstract string[] WidgetNames { get; }
    public Widget[] Widgets { get; private set; }
    protected IPutWidget[] IPutWidgets { get; private set; }

    public string Key => GetType().Name;
    public string GetKey => Key;

    public void Bind()
    {
        List<Widget> widgetList = new List<Widget>();
        List<IPutWidget> iPutWidgetList = new List<IPutWidget>();
        foreach (string widgetName in WidgetNames)
        {
            Widget widget = Game.SingletonRepository.Widgets.Get(widgetName);
            if (typeof(IPutWidget).IsAssignableFrom(widget.GetType()))
            {
                iPutWidgetList.Add((IPutWidget)widget);
            }
            widgetList.Add(widget);
        }
        Widgets = widgetList.ToArray();
        IPutWidgets = iPutWidgetList.ToArray();
    }

    public string ToJson()
    {
        return "";
    }

    public void Invalidate()
    {
        // Clear the screen.
        Game.MsgPrint(null);
        Game.Screen.Clear();

        // Force all of the widgets to redraw.
        foreach (Widget widget in Widgets)
        {
            widget.Invalidate();
        }
    }

    /// <summary>
    /// Draws a character in a specified color at a specific map location.  The map is not updated and the cursor is not moved.  This method is used by projectiles and animations.
    /// </summary>
    /// <param name="c"></param>
    /// <param name="a"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    public void PutCharAtMapLocation(char c, ColorEnum a, int y, int x)
    {
        if (Game.PanelContains(y, x))
        {
            PutMapChar(c, a, y, x);
        }
    }

    private void PutMapChar(char c, ColorEnum a, int y, int x)
    {
        if (Game.InvulnerabilityTimer.Value != 0)
        {
            a = ColorEnum.White;
        }
        else if (Game.EtherealnessTimer.Value != 0)
        {
            a = ColorEnum.Black;
        }

        foreach (IPutWidget widget in IPutWidgets)
        {
            IPutWidget putWidget = (IPutWidget)widget;
            putWidget.PutChar(a, c, y, x);
        }
    }

    /// <summary>
    /// Moves the cursor to a specific map location and redraws the map location.
    /// </summary>
    /// <param name="y"></param>
    /// <param name="x"></param>
    public void RefreshMapLocation(int y, int x)
    {
        if (Game.PanelContains(y, x)) // TODO: This check is now done twice.
        {
            Game.MapInfo(y, x, out ColorEnum a, out char c);
            PutMapChar(c, a, y, x);
        }
    }

    /// <summary>
    /// Locate the cursor in the viewport at a specific level grid x, y coordinate.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    public void GotoMapLocation(int row, int col)
    {
        foreach (IPutWidget widget in IPutWidgets) 
        {
            IPutWidget putWidget = (IPutWidget)widget;
            putWidget.Goto(row, col);
        }
    }
}
