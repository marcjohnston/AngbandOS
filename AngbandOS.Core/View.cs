// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Configuration;
namespace AngbandOS.Core;

/// <summary>
/// Represents a view (or layout) of widgets used to render the UI.  Views consist of widgets and must conform to the window.
/// </summary>
[Serializable]
internal class View : IGetKey
{
    #region State Data
    protected readonly Game Game;

    /// <summary>
    /// Returns the widgets that support the ability to "poke" a character directly into a dungeon map; or null, if the pokeable widgets haven't been bound yet.  These types of 
    /// widgets are the only widgets that "Update" inbetween the widget update phases.  Binding of pokeable widgets cannot be performed during the binding phase because the
    /// widgets themselves may not have been bound when the form binds; in that case, null is used.
    /// </summary>
    private Widget[]? PokeWidgets = null;
    #endregion

    #region Constructors
    public View(Game game, ViewGameConfiguration viewGameConfiguration)
    {
        Game = game;
        Key = viewGameConfiguration.Key ?? viewGameConfiguration.GetType().Name;
        WidgetNames = viewGameConfiguration.WidgetNames;
    }
    #endregion

    #region Bound Properties
    public Widget[] Widgets { get; private set; }
    #endregion

    #region Api Methods
    public void Refresh()
    {
        // Call the update method for each widget.  This allows the widget to render.
        foreach (Widget widget in Widgets)
        {
            widget.Update();
        }
    }

    public string GetKey => Key;

    public void Bind()
    {
        Widgets = Game.SingletonRepository.Get<Widget>(WidgetNames);
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
        ViewGameConfiguration definition = new ViewGameConfiguration()
        {
            Key = Key,
            WidgetNames = WidgetNames,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
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
    #endregion

    #region Light-weight Virtuals and Abstracts
    public virtual string Key { get; }
    protected virtual string[] WidgetNames { get; }
    #endregion
}

