// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class TextAreaWidget : Widget, IGetKey
{
    public TextAreaWidget(Game game, TextAreaWidgetGameConfiguration nullableStringsTextAreaWidgetGameConfiguration) : base(game)
    {
        Key = nullableStringsTextAreaWidgetGameConfiguration.Key ?? nullableStringsTextAreaWidgetGameConfiguration.GetType().Name;
        NullableTextAreaValueName = nullableStringsTextAreaWidgetGameConfiguration.NullableTextAreaValueName;
        NullableText = nullableStringsTextAreaWidgetGameConfiguration.NullableText;
        Color = nullableStringsTextAreaWidgetGameConfiguration.Color;
        X = nullableStringsTextAreaWidgetGameConfiguration.X;
        Y = nullableStringsTextAreaWidgetGameConfiguration.Y;
        Width = nullableStringsTextAreaWidgetGameConfiguration.Width;
        Height = nullableStringsTextAreaWidgetGameConfiguration.Height;
        JustificationName = nullableStringsTextAreaWidgetGameConfiguration.JustificationName;
        AlignmentName = nullableStringsTextAreaWidgetGameConfiguration.AlignmentName;
        ChangeTrackerNames = nullableStringsTextAreaWidgetGameConfiguration.ChangeTrackerNames;
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
        Alignment = Game.SingletonRepository.Get<Alignment>(AlignmentName);
        NullableTextAreaValue = Game.SingletonRepository.Get<INullableStringsValue>(NullableTextAreaValueName);
    }

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
    public virtual int Width { get; }

    /// <summary>
    /// Returns the height of the widget.  If the height provided is less than the number of lines in the <see cref="Text"/> property, remaining lines will not be rendered.
    /// </summary>
    public virtual int Height { get; }

    /// <summary>
    /// Returns the <see cref="Justification"/> object to be used to justify the each line of the text within the <see cref="Width"/> of the <see cref="TextWidget"/>.  This property
    /// is bound using the <see cref="JustificationName"/> property during the bind phase.
    /// </summary>
    protected Justification Justification { get; private set; }

    /// <summary>
    /// Returns the <see cref="Alignment"/> object to be used to align the text in the <see cref="Height"/> specified.  This property is bound using the <see cref="AlignmentName"/>
    /// property during the bind phase.
    /// </summary>
    protected Alignment Alignment { get; private set; }

    /// <summary>
    /// Returns the name of the <see cref="Alignment"/> object to be used to align the text in the <see cref="Height"/> specified.  This property is used to bind the <see cref="Alignment"/>
    /// property during the bind phase.
    /// </summary>
    public virtual string AlignmentName { get; }

    /// <summary>
    /// Returns the name of the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="TextWidget" />.  This property
    /// is used to bind the <see cref="Justification"/> property.  Defaults to <see cref="LeftJustification"/>.
    /// </summary>
    public virtual string JustificationName { get; } = nameof(LeftJustification);

    ///// <summary>
    ///// Returns the text to be rendered for the widget.
    ///// </summary>
    //public virtual string[] Text => NullableText ?? NullText;

    /// <summary>
    /// Paint the widget on the screen.  No checks or resets of the validation status are or should be performed during this method.
    /// </summary>
    protected override void Paint()
    {
        // Align the text vertically.
        string[] text = NullableTextAreaValue.NullableStringsValue ?? NullText;
        string[] alignedText = Alignment.Align(text, Height);

        // Ensure we do not exceed the maximum height.
        alignedText = alignedText.Take(Height).ToArray();

        int currentY = Y;
        foreach (string line in alignedText)
        {
            string justifiedText = Justification.Format(line, Width);
            Game.Screen.Print(Color, justifiedText, currentY, X);
            currentY++;
        }
    }

    /// <summary>
    /// Returns the text to render when the value is null.  By default, returns a single line of an empty string.  The alignment will vertically add lines and the justification
    /// will horizontally add space.
    /// </summary>
    public virtual string[] NullText { get; } = new string[] { String.Empty };

    public virtual string NullableTextAreaValueName { get; }
    public INullableStringsValue NullableTextAreaValue { get; private set; }
    /// <summary>
    /// Returns the text to be rendered for the widget.
    /// </summary>
    public virtual string[]? NullableText { get; }
    public string ToJson()
    {
        TextAreaWidgetGameConfiguration nullableStringsTextAreaWidgetGameConfiguration = new TextAreaWidgetGameConfiguration()
        {
            Key = Key,
            NullableTextAreaValueName = NullableTextAreaValueName,
            NullableText = NullableText,
            Color = Color,
            X = X,
            Y = Y,
            JustificationName = JustificationName,
            AlignmentName = AlignmentName,
            ChangeTrackerNames = ChangeTrackerNames,
        };
        return JsonSerializer.Serialize(nullableStringsTextAreaWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }
}
