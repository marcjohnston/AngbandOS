// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core;

/// <summary>
/// Represents a widget that renders a single line of text at the coordinates specified by <see cref="X"/> and <see cref="Y"/>.  Text is automatically justified using the <see cref="Justification"/>
/// property within the space provided by the <see cref="Width"/> property.  The text is drawn in the color specified by the <see cref="Color"/> property.
/// </summary>
[Serializable]
internal class TextWidget : Widget, IGetKey
{
    protected TextWidget(Game game) : base(game) { } // TODO: Remove this
    public TextWidget(Game game, TextWidgetGameConfiguration textWidgetGameConfiguration) : base(game)
    {
        Key = textWidgetGameConfiguration.Key ?? textWidgetGameConfiguration.GetType().Name;
        Text = textWidgetGameConfiguration.Text;
        Color = textWidgetGameConfiguration.Color;
        X = textWidgetGameConfiguration.X;
        Y = textWidgetGameConfiguration.Y;
        Width = textWidgetGameConfiguration.Width;
        JustificationName = textWidgetGameConfiguration.JustificationName;
        ChangeTrackerNames = textWidgetGameConfiguration.ChangeTrackerNames;
    }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public virtual string[]? ChangeTrackerNames { get; } = null;

    public virtual string Key { get; }

    public string GetKey => Key;

    public virtual void Bind()
    {
        ChangeTrackers = Game.SingletonRepository.GetNullable<IChangeTracker>(ChangeTrackerNames);
        Justification = Game.SingletonRepository.Get<Justification>(JustificationName);
    }

    public virtual string ToJson()
    {
        TextWidgetGameConfiguration textWidgetGameConfiguration = new TextWidgetGameConfiguration()
        {
            Key = Key,
            Text = Text,
            Color = Color,
            X = X,
            Y = Y,
            Width = Width,
            JustificationName = JustificationName,
            ChangeTrackerNames = ChangeTrackerNames,
        };
        return JsonSerializer.Serialize(textWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }

    /// <summary>
    /// Returns the text to be rendered for the widget.
    /// </summary>
    public virtual string Text { get; }

    /// <summary>
    /// Returns the color that the widget <see cref="Text"/> will be drawn.  Returns the color white by default.
    /// </summary>
    public virtual ColorEnum Color { get; } = ColorEnum.White;

    /// <summary>
    /// Returns the x-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public virtual int X { get; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public virtual int Y { get; }

    /// <summary>
    /// Returns the width of the widget.  A width that is equal to the length of the <see cref="Text"/> property is returned by default.
    /// </summary>
    public virtual int? Width { get; } = null;

    /// <summary>
    /// Returns the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="TextWidget"/>.  This property is bound using
    /// the <see cref="JustificationName"/> property during the bind phase.
    /// </summary>
    protected Justification Justification { get; private set; }

    /// <summary>
    /// Returns the name of the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="TextWidget" />.  This property
    /// is used to bind the <see cref="Justification"/> property.  Defaults to <see cref="LeftJustification"/>.
    /// </summary>
    public virtual string JustificationName { get; } = nameof(LeftJustification);

    /// <summary>
    /// Paint the widget on the screen.  No checks or resets of the validation status are or should be performed during this method.
    /// </summary>
    protected override void Paint()
    {
        string justifiedText = Text;
        justifiedText = Justification.Format(justifiedText, Width ?? justifiedText.Length);
        Game.Screen.Print(Color, justifiedText, Y, X);
    }
}
