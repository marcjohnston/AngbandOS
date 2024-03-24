// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using static System.Net.Mime.MediaTypeNames;
using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class MapWidget : Widget, IPutWidget
{
    protected MapWidget(Game game) : base(game) { }

    public abstract string MapChangeTrackingName { get; }
    public IMapChangeTracking MapChangeTracking { get; private set; }

    /// <summary>
    /// Returns the x-coordinate on the <see cref="Form"/> where the widget will be drawn.
    /// </summary>
    public abstract int X { get; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="Form"/> where the widget will be drawn.
    /// </summary>
    public abstract int Y { get; }

    public override void Bind()
    {
        base.Bind();
        Property? property = Game.SingletonRepository.Properties.TryGet(MapChangeTrackingName);
        if (property != null)
        {
            MapChangeTracking = (IMapChangeTracking)property;
        }
        else
        {
            Timer? timer = Game.SingletonRepository.TimedActions.TryGet(MapChangeTrackingName);
            if (timer != null)
            {
                MapChangeTracking = (IMapChangeTracking)timer;
            }
            else
            {
                Function? function = Game.SingletonRepository.Functions.TryGet(MapChangeTrackingName);
                if (function != null)
                {
                    MapChangeTracking = (IMapChangeTracking)function;
                }
                else
                {
                    throw new Exception($"The {nameof(MapChangeTrackingName)} property does not specify a valid {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                }
            }
        }
    }

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
        Game.RedrawSingleLocation(Game.MapY, Game.MapX);

        // Restore the cursor visible.
        Game.Screen.CursorVisible = v;
    }

    public override void Update()
    {
        // Check to see if the value has changed.
        if (MapChangeTracking.IsChanged)
        {
            // It has, invalidate the widget.
            base.Invalidate();
        }

        // Update the widget.
        base.Update();
    }

    public void MoveCursorRelative(int row, int col)
    {
        int offsetX = Game.PanelColMin - X;
        int offsetY = Game.PanelRowMin - Y;
        Game.Screen.Goto(row - offsetY, col - offsetX); // TODO: The - is weird and should be +
    }

    public void PutChar(ColorEnum attr, char ch, int row, int col)
    {
        int offsetX = Game.PanelColMin - X;
        int offsetY = Game.PanelRowMin - Y;
        Game.Screen.PutChar(attr, ch, row - offsetY, col -+ offsetX);// TODO: The - is weird and should be +
    }

    public void Print(ColorEnum attr, char ch, int row, int col) // TODO: Should use PutChar
    {
        int offsetX = Game.PanelColMin - X;
        int offsetY = Game.PanelRowMin - Y;
        Game.Screen.Print(attr, ch, row - offsetY, col - offsetX); // TODO: The - is weird and should be +
    }
}
