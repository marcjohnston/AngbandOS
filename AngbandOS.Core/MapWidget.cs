// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Drawing;
using System.Text.Json;

namespace AngbandOS.Core;

/// <summary>
/// Represents a widget that renders a dungeon map.  This widget supports the ability to "poke" a character directly into the map grid.
/// </summary>
[Serializable]
internal abstract class MapWidget : Widget, IGetKey
{
    protected MapWidget(Game game) : base(game) { }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public virtual string[]? ChangeTrackerNames => null;

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public virtual void Bind()
    {
        ChangeTrackers = Game.SingletonRepository.GetNullable<IChangeTracker>(ChangeTrackerNames);
    }

    public virtual string ToJson()
    {
        MapWidgetGameConfiguration mapWidgetGameConfiguration = new MapWidgetGameConfiguration()
        {
            Key = Key,
            X = X,
            Y = Y,
            ChangeTrackerNames = ChangeTrackerNames,
        };
        return JsonSerializer.Serialize(mapWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }

    public override bool CanPoke => true;

    /// <summary>
    /// Returns the x-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public abstract int X { get; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public abstract int Y { get; }

    protected override void Paint()
    {
        // Save the cursor visible state, we will temporarily reset it.
        bool v = Game.Screen.CursorVisible;

        // Turn off the cursor visible.
        Game.Screen.CursorVisible = false; // TODO: Is this really needed, if we have a double-buffer?
        int offsetX = Game.PanelColMin - X;
        int offsetY = Game.PanelRowMin - Y;
        for (int y = Game.PanelRowMin; y <= Game.PanelRowMax; y++)
        {
            for (int x = Game.PanelColMin; x <= Game.PanelColMax; x++)
            {
                Game.MapInfo(y, x, out ColorEnum a, out char c);
                if (Game.InvulnerabilityTimer.Value != 0)
                {
                    a = ColorEnum.White;
                }
                else if (Game.EtherealnessTimer.Value != 0)
                {
                    a = ColorEnum.Black;
                }
                Game.Screen.Print(a, c, y - offsetY, x - offsetX); // TODO: The - is weird and should be +
            }
        }
        Game.ConsoleView.RefreshMapLocation(Game.MapY.IntValue, Game.MapX.IntValue);

        // Restore the cursor visible.
        Game.Screen.CursorVisible = v;
    }

    /// <summary>
    /// Locate the cursor in the viewport at a specific level grid x, y coordinate.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    public override void MoveCursorTo(int row, int col)
    {
        int offsetX = Game.PanelColMin - X;
        int offsetY = Game.PanelRowMin - Y;
        Game.Screen.Goto(row - offsetY, col - offsetX); // TODO: The - is weird and should be +
    }

    public override void Poke(ColorEnum attr, char ch, int row, int col)
    {
        int offsetX = Game.PanelColMin - X;
        int offsetY = Game.PanelRowMin - Y;
        Game.Screen.PutChar(attr, ch, row - offsetY, col -+ offsetX);// TODO: The - is weird and should be +
    }
}
