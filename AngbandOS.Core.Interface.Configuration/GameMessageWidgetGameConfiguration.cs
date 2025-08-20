namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class GameMessageWidgetGameConfiguration
{
    /// <summary>
    /// Returns the color that the widget <see cref="Text"/> will be drawn.  Returns the color white by default.
    /// </summary>
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    /// <summary>
    /// Returns the x-coordinate on the <see cref="Form"/> where the widget will be drawn.
    /// </summary>
    public virtual int X { get; set; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="Form"/> where the widget will be drawn.
    /// </summary>
    public virtual int Y { get; set; }

    /// <summary>
    /// Returns the width of the widget.  A width that is equal to the length of the <see cref="Text"/> property is returned by default.
    /// </summary>
    public virtual int? Width { get; set; } = null;

    public virtual string? Key { get; set; } = null;
}

