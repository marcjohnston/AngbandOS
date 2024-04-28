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

    /// <summary>
    /// Returns the widgets that support the ability to "poke" a character directly into a dungeon map; or null, if the pokeable widgets haven't been bound yet.  These types of 
    /// widgets are the only widgets that "Update" inbetween the widget update phases.  Binding of pokeable widgets cannot be performed during the binding phase because the
    /// widgets themselves may not have been bound when the form binds; in that case, null is used.
    /// </summary>
    private Widget[]? PokeWidgets = null;

    public string Key => GetType().Name;
    public string GetKey => Key;

    public void Bind()
    {
        List<Widget> widgetList = new List<Widget>();
        foreach (string widgetName in WidgetNames)
        {
            widgetList.Add(Game.SingletonRepository.Get<Widget>(widgetName));
        }
        Widgets = widgetList.ToArray();
    }

    private Widget[] GetPokeWidgets()
    {
        List<Widget> iPutWidgetList = new List<Widget>();
        foreach (Widget widget in Widgets)
        {
            if (widget.CanPoke)
            {
                iPutWidgetList.Add(widget);
            }
        }
        return iPutWidgetList.ToArray();
    }

    public string ToJson()
    {
        return "";
    }

    /// <summary>
    /// Invalidates all of the widgets that are associated with the form.  This will force all widgets to be redrawn.
    /// </summary>
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
            Poke(c, a, y, x);
        }
    }

    private void Poke(char c, ColorEnum a, int y, int x)
    {
        if (Game.InvulnerabilityTimer.Value != 0)
        {
            a = ColorEnum.White;
        }
        else if (Game.EtherealnessTimer.Value != 0)
        {
            a = ColorEnum.Black;
        }

        if (PokeWidgets == null)
        {
            PokeWidgets = GetPokeWidgets();
        }

        foreach (Widget widget in PokeWidgets)
        {
            widget.Poke(a, c, y, x);
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
            Poke(c, a, y, x);
        }
    }

    /// <summary>
    /// Locate the cursor in the viewport at a specific level grid x, y coordinate.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    public void MoveCursorTo(int row, int col)
    {
        if (PokeWidgets == null)
        {
            PokeWidgets = GetPokeWidgets();
        }

        foreach (Widget widget in PokeWidgets) 
        {
            widget.MoveCursorTo(row, col);
        }
    }
}
