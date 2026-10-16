// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Game Message Widget",
    EntityNoun = "GameMessageWidget")]
public class GameMessageWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Color",
        Summary = "The color used to draw the widget's text.",
        DataType = "ColorEnum")]
    /// <remarks>
    /// Defaults to <see cref="ColorEnum.White"/>. Change this to any value from <see cref="ColorEnum"/>
    /// to alter the message text color. The exact rendering behavior (e.g., palettes, intensity)
    /// is determined by the UI implementation that consumes this configuration.
    /// </remarks>
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationMetadataAttribute(
        Title = "X",
        Summary = "X-coordinate (horizontal) of the widget's top-left corner on the Form.",
        DataType = "int")]
    /// <remarks>
    /// Coordinate system is the <see cref="Form"/>'s client area with (0,0) at the top-left.
    /// This value is in character/cell units or pixels depending on the UI layer that consumes it —
    /// consult the rendering layer for the expected unit. Use 0 to align with the left edge.
    /// </remarks>
    public virtual int X { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Y",
        Summary = "Y-coordinate (vertical) of the widget's top-left corner on the Form.",
        DataType = "int")]
    /// <remarks>
    /// Coordinate system is the <see cref="Form"/>'s client area with (0,0) at the top-left.
    /// This value is in character/cell units or pixels depending on the UI layer that consumes it —
    /// consult the rendering layer for the expected unit. Use 0 to align with the top edge.
    /// </remarks>
    public virtual int Y { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Width",
        Summary = "Width of the widget; when null, the widget should extend to the remaining width of the screen.",
        DataType = "int?")]
    /// <remarks>
    /// If specified, this value constrains the visible width of the message area. If <c>null</c>,
    /// the UI should calculate the remaining available width on the line starting at <see cref="X"/>.
    /// The consuming UI should handle wrapping or truncation according to its policy.
    /// </remarks>
    public virtual int? Width { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "More Prompt",
        Summary = "Text used for the \"more\" prompt when message output is paused.",
        DataType = "string")]
    /// <remarks>
    /// Defaults to <c>"-more-"</c>. The UI will display this prompt (or an equivalent indicator)
    /// when the message widget requires user interaction to continue (for example when there are
    /// more messages than can be shown at once). Localize or change this string if needed.
    /// </remarks>
    public virtual string MorePrompt { get; set; } = "-more-";
}
