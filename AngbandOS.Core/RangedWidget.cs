// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class RangedWidget : Widget, IGetKey, IToJson
{
    private string _text;
    private ColorEnum _color;

    public RangedWidget(Game game, RangedWidgetGameConfiguration rangedWidgetGameConfiguration) : base(game)
    {
        Key = rangedWidgetGameConfiguration.Key ?? rangedWidgetGameConfiguration.GetType().Name;
        Ranges = rangedWidgetGameConfiguration.Ranges;
        IntValueName = rangedWidgetGameConfiguration.IntValueName;
        DefaultText = rangedWidgetGameConfiguration.DefaultText;
        DefaultColor = rangedWidgetGameConfiguration.DefaultColor;
        X = rangedWidgetGameConfiguration.X;
        Y = rangedWidgetGameConfiguration.Y;
        Width = rangedWidgetGameConfiguration.Width;
        JustificationName = rangedWidgetGameConfiguration.JustificationName;
        ChangeTrackerNames = rangedWidgetGameConfiguration.ChangeTrackerNames;
        _text = DefaultText;
        _color = DefaultColor;
    }

    public string Key { get; }

    public string GetKey => Key;

    public void Bind()
    {
        ChangeTrackers = Game.SingletonRepository.GetNullable<IChangeTracker>(ChangeTrackerNames);
        Justification = Game.SingletonRepository.Get<Justification>(JustificationName);
        IntValue = Game.SingletonRepository.Get<IIntValue>(IntValueName);

        // Validate the sort order for the Ranges; from smallest startValue to largest.
        if (!Game.ValidateTupleSorting<(int startValue, string text, ColorEnum color)>(Ranges, (a, b) => a.startValue > b.startValue))
        {
            throw new Exception($"The ranges specified for the {GetType().Name} are not sorted in descending order by startValue.");
        }
    }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public string[]? ChangeTrackerNames { get; } = null;

    /// <summary>
    /// Returns the x-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public int Y { get; }

    /// <summary>
    /// Returns the width of the widget.  A width that is equal to the length of the <see cref="Text"/> property is returned by default.
    /// </summary>
    public int? Width { get; } = null;

    /// <summary>
    /// Returns the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="LabelWidget"/>.  This property is bound using
    /// the <see cref="JustificationName"/> property during the bind phase.
    /// </summary>
    private Justification Justification { get; set; }

    /// <summary>
    /// Returns the name of the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="LabelWidget" />.  This property
    /// is used to bind the <see cref="Justification"/> property.  Defaults to <see cref="LeftJustification"/>.
    /// </summary>
    public string JustificationName { get; } = nameof(LeftJustification);

    /// <summary>
    /// Returns an array of tuples that specify the text and color to render for a range of values.  The <paramref name="startValue"/> element specifies the smallest (or start) value of the range.  Ranges must be sorted in
    /// descending order (from the largest value to the smallest).  This sorting is validated once upon first usage.  If the value is larger than the first range, the first range will match.  If the value is smaller than the last range specified, the
    /// <see cref="DefaultText"/> and <see cref="DefaultColor"/> will be used.  Duplicate <paramref name="startValue"/> element cannot be used and will fail the sort validation.
    /// </summary>
    public (int startValue, string textToRender, ColorEnum color)[] Ranges { get; }

    public string IntValueName { get; }
    public IIntValue IntValue { get; private set; }

    /// <summary>
    /// Returns the text to be rendered for the widget.
    /// </summary>
    public string Text => _text;

    /// <summary>
    /// Returns the color that the widget <see cref="Text"/> will be drawn.  Returns the color white by default.
    /// </summary>
    public ColorEnum Color => _color;

    /// <summary>
    /// Returns the text to be rendered, when none of the ranges apply.  Returns an empty string, by default.
    /// </summary>
    private string DefaultText { get; } = "";

    /// <summary>
    /// Returns the color for the <see cref="Text"/> to be rendered in when none of the ranges apply.  Returns the color white, by default.
    /// </summary>
    private ColorEnum DefaultColor { get; } = ColorEnum.White;

    public override void Update()
    {
        // Grab a copy of the value so that we do not retrieve it for every range.
        int intValue = IntValue.IntValue;

        // Apply the default text and color.
        (string text, ColorEnum color) found = (DefaultText, DefaultColor);

        // Scan the ranges for the first valid range.
        foreach ((int startValue, string textToRender, ColorEnum color) in Ranges)
        {
            if (intValue >= startValue)
            {
                found = (textToRender, color);
                break;
            }
        }

        // Check to see if the value has changed.
        if (found.text != _text || found.color != _color)
        {
            // Update the exposed value and color.
            _text = found.text;
            _color = found.color;

            Invalidate();
        }

        base.Update();
    }
    public string ToJson()
    {
        RangedWidgetGameConfiguration rangedWidgetGameConfiguration = new RangedWidgetGameConfiguration()
        {
            Key = Key,
            Ranges = Ranges,
            IntValueName = IntValueName,
            DefaultText = DefaultText,
            DefaultColor = DefaultColor,
            X = X,
            Y = Y,
            Width = Width,
            JustificationName = JustificationName,
            ChangeTrackerNames = ChangeTrackerNames,
        };
        return JsonSerializer.Serialize(rangedWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }

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
