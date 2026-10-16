using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Configuration for an integer-valued widget.
/// </summary>
/// <remarks>
/// Provides binding and layout settings for widgets that display an integer value.
/// Properties are virtual to permit overriding in derived configurations or for test doubles.
/// </remarks>
[ConfigurationEntity(Title = "Integer Widget", EntityNoun = "integer widget")]
public class IntWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    /// <summary>
    /// Name of the integer value property to bind to (e.g., a view model property name).
    /// </summary>
    /// <remarks>
    /// The consuming UI layer will resolve this name against the data context to obtain the value
    /// to display. This should match the property name used by the owning model or state object.
    /// </remarks>
    [ConfigurationMetadata(
        Title = "Integer Value Name",
        Summary = "The name of the integer value property to bind to.",
        DataType = "string")]
    public virtual string IntValueName { get; set; }

    /// <summary>
    /// The color used to draw the widget's text.
    /// </summary>
    /// <remarks>
    /// If not explicitly set, the rendering layer may apply a default color (commonly
    /// <see cref="ColorEnum.White"/>). The exact visual result depends on the UI implementation.
    /// </remarks>
    [ConfigurationMetadata(
        Title = "Color",
        Summary = "The color used to draw the widget's text.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; }

    /// <summary>
    /// X-coordinate (horizontal) of the widget's top-left corner on the <see cref="Form"/>.
    /// </summary>
    /// <remarks>
    /// Coordinate units (pixels vs character cells) are determined by the rendering layer that
    /// consumes this configuration. Use 0 to align with the left edge of the client area.
    /// </remarks>
    [ConfigurationMetadata(
        Title = "X",
        Summary = "The horizontal coordinate of the widget's top-left corner.",
        DataType = "int")]
    public virtual int X { get; set; }

    /// <summary>
    /// Y-coordinate (vertical) of the widget's top-left corner on the <see cref="Form"/>.
    /// </summary>
    /// <remarks>
    /// Coordinate units (pixels vs character cells) are determined by the rendering layer that
    /// consumes this configuration. Use 0 to align with the top edge of the client area.
    /// </remarks>
    [ConfigurationMetadata(
        Title = "Y",
        Summary = "The vertical coordinate of the widget's top-left corner.",
        DataType = "int")]
    public virtual int Y { get; set; }

    /// <summary>
    /// Width of the widget. When null, the widget width defaults to the length required to display the text.
    /// </summary>
    /// <remarks>
    /// A non-null value constrains the visible width of the integer display. If null, the UI should
    /// size the widget to the natural length of the rendered text (including sign and any formatting).
    /// The consuming UI should handle wrapping or truncation according to its policy.
    /// </remarks>
    [ConfigurationMetadata(
        Title = "Width",
        Summary = "The width of the widget, or null to size it to the natural length of the rendered text.",
        DataType = "int?")]
    public virtual int? Width { get; set; } = null;

    /// <summary>
    /// Name of the justification strategy to use when laying out the text within <see cref="Width"/>.
    /// </summary>
    /// <remarks>
    /// Defaults to <see cref="LeftJustification"/> (via <c>nameof(JustificationsEnum.LeftJustification)</c>).
    /// The UI will resolve this name to a justification object or rule during binding.
    /// </remarks>
    [ConfigurationMetadata(
        Title = "Justification Name",
        Summary = "The name of the justification strategy used to lay out the text within the widget width.",
        DataType = "string")]
    public virtual string JustificationName { get; set; } = nameof(JustificationsEnum.LeftJustification);

    /// <summary>
    /// Names of properties that participate in change-tracking for this widget.
    /// </summary>
    /// <remarks>
    /// During binding the change-tracker names are used to subscribe to updates so the UI can
    /// refresh when the underlying value(s) change. Provide one or more property names as needed,
    /// or null when no explicit change tracking is required.
    /// </remarks>
    [ConfigurationMetadata(
        Title = "Change Tracker Names",
        Summary = "The names of properties that participate in change tracking for this widget.",
        DataType = "string[]?")]
    public virtual string[]? ChangeTrackerNames { get; set; }
}

