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

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTracking"/> property during the bind phase.
    /// </summary>
    public abstract string ChangeTrackingName { get; }

    /// <summary>
    /// Returns the property that participates in change tracking.  This property is bound from the <see cref="ChangeTrackingName"/> property during the bind phase.
    /// </summary>
    public IChangeTracking ChangeTracking { get; private set; }

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
        Property? property = Game.SingletonRepository.Properties.TryGet(ChangeTrackingName);
        if (property != null)
        {
            ChangeTracking = (IChangeTracking)property;
        }
        else
        {
            Timer? timer = Game.SingletonRepository.Timers.TryGet(ChangeTrackingName);
            if (timer != null)
            {
                ChangeTracking = (IChangeTracking)timer;
            }
            else
            {
                Function? function = Game.SingletonRepository.Functions.TryGet(ChangeTrackingName);
                if (function != null)
                {
                    ChangeTracking = (IChangeTracking)function;
                }
                else
                {
                    throw new Exception($"The {ChangeTrackingName} property does not specify a valid {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                }
            }
        }

        List<Widget> widgetList = new List<Widget>();
        foreach (string widgetName in WidgetNames)
        {
            widgetList.Add(Game.SingletonRepository.Widgets.Get(widgetName));
        }
        Widgets = widgetList.ToArray();
    }

    public override void Update()
    {
        // Check to see if the value has changed.
        if (IsInvalid || ChangeTracking.IsChanged)
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
