namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class MapWidgetGameConfiguration
{
    /// <summary>
    /// Returns the x-coordinate on the <see cref="Form"/> where the widget will be drawn.
    /// </summary>
    public virtual int X { get; set; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="Form"/> where the widget will be drawn.
    /// </summary>
    public virtual int Y { get; set; }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public virtual string[]? ChangeTrackerNames { get; set; }
    public virtual string Key { get; set; }
}


