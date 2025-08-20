// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an on-screen widget that renders game data.  Widgets are invalidated when they need to be updated.  The Update method determines whether or not the widget
/// needs to be updated and the Paint method is used to actually draw the widget.  
/// </summary>
[Serializable]
internal abstract class Widget
{
    protected readonly Game Game;
    protected Widget(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the property that participates in change tracking.  This property is bound from the <see cref="ChangeTrackerNames"/> property during the bind phase.
    /// </summary>
    protected IChangeTracker[]? ChangeTrackers { get; set; }

    public virtual bool CanPoke => false;

    /// <summary>
    /// Locate the cursor in the viewport at a specific level grid x, y coordinate.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    public virtual void MoveCursorTo(int row, int col) { }

    public virtual void Poke(ColorEnum attr, char ch, int row, int col) {}

    /// <summary>
    /// Returns true, if the widget is invalid and needs to be redrawn.
    /// </summary>
    public bool IsInvalid { get; private set; } = true;

    /// <summary>
    /// Invalidates the widget.  An invalidated widget will call the <see cref="Paint"/> method, when the <see cref="Update"/> method is called.
    /// </summary>
    public void Invalidate()
    {
        IsInvalid = true;
    }

    /// <summary>
    /// Paint the widget on the screen.  No checks or resets of the validation status are or should be performed during this method.
    /// </summary>
    protected abstract void Paint();

    /// <summary>
    /// Update the widget on the screen, if the widget needs to be redrawn.  The widget will be redrawn, if the widget was invalidated or the derived widget returns true
    /// on the QueryRedraw method.
    /// </summary>
    public virtual void Update()
    {
        // If the widget is not invalid, and there are change trackers, check the change trackers and invalidate the widget.
        if (!IsInvalid && ChangeTrackers is not null && ChangeTrackers.Any(_changeTracker => _changeTracker.IsChanged))
        {
            // It has, invalidate the widget.
            Invalidate();

            // Now force the widget to update.
            Update();
        }

        // If this widget is invalid, paint it and validate it.
        if (IsInvalid)
        {
            Paint();

            // Now that the widget has been draw, validate it.
            IsInvalid = false;
        }
    }
}
