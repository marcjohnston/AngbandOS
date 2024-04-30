// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents a widget that invalidates a child widget when a change in a property value is detected.
/// </summary>
[Serializable]
internal abstract class ChangeTrackingWidget : Widget
{
    protected ChangeTrackingWidget(Game game) : base(game) { }

    private Widget[]? PokeableWidgets = null;
    private bool _hasPokeableWidgets = false;

    public override bool CanPoke => _hasPokeableWidgets;

    public override void MoveCursorTo(int row, int col)
    {
        if (PokeableWidgets != null)
        {
            foreach (Widget pokeableWidget in PokeableWidgets)
            {
                pokeableWidget.MoveCursorTo(row, col);
            }
        }
    }

    public override void Poke(ColorEnum attr, char ch, int row, int col)    
    {
        if (PokeableWidgets != null)
        {
            foreach (Widget pokeableWidget in PokeableWidgets)
            {
                pokeableWidget.Poke(attr, ch, row, col);
            }
        }
    }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public abstract string[] ChangeTrackerNames { get; }

    /// <summary>
    /// Returns the property that participates in change tracking.  This property is bound from the <see cref="ChangeTrackerNames"/> property during the bind phase.
    /// </summary>
    public IChangeTracker[] ChangeTrackers { get; private set; }

    /// <summary>
    /// Returns the name of the widget to render when the change tracking property of the specified property indicates that the value has changed.  This property is
    /// used to bind the <see cref="Widgets"/> property during the bind phase.
    /// </summary>
    public abstract string[] WidgetNames { get; }

    /// <summary>
    /// Returns the widget to render when the change tracking indicates that the dependent property value has changed.  This property is bound using the <see cref="WidgetNames"/>
    /// property during the bind phase.
    /// </summary>
    protected Widget[] Widgets { get; private set; }

    public override void Bind()
    {
        base.Bind();
        ChangeTrackers = Game.SingletonRepository.Get<IChangeTracker>(ChangeTrackerNames);
        Widgets = Game.SingletonRepository.Get<Widget>(WidgetNames);
        PokeableWidgets = Widgets.Where(_widget => _widget.CanPoke).ToArray();
        _hasPokeableWidgets = PokeableWidgets.Length > 0;
    }

    public override void Update()
    {
        // Check to see if the value has changed.
        if (IsInvalid || ChangeTrackers.Any(_changeTracker => _changeTracker.IsChanged))
        {
            foreach (Widget widget in Widgets)
            {
                // It has, invalidate the widget.
                widget.Invalidate();

                // Now force the widget to update.
                widget.Update();
            }
        }

        // Update this widget.
        base.Update();
    }

    protected override void Paint() {  }
}
