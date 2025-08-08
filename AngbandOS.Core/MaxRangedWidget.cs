// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class MaxRangedWidget : Widget, IGetKey, IToJson
{
    private bool _sortValidated = false;
    private string _value;
    private ColorEnum _color;

    public MaxRangedWidget(Game game, MaxRangedWidgetGameConfiguration maxRangedWidgetGameConfiguration) : base(game)
    {
        Key = maxRangedWidgetGameConfiguration.Key ?? maxRangedWidgetGameConfiguration.GetType().Name;
        Ranges = maxRangedWidgetGameConfiguration.Ranges;
        DefaultColor = maxRangedWidgetGameConfiguration.DefaultColor;
        MaxIntValueName = maxRangedWidgetGameConfiguration.MaxIntValueName;
        IntValueName = maxRangedWidgetGameConfiguration.IntValueName;
        X = maxRangedWidgetGameConfiguration.X;
        Y = maxRangedWidgetGameConfiguration.Y;
        Width = maxRangedWidgetGameConfiguration.Width;
        JustificationName = maxRangedWidgetGameConfiguration.JustificationName;
        ChangeTrackerNames = maxRangedWidgetGameConfiguration.ChangeTrackerNames;
        _color = DefaultColor;
    }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public string[]? ChangeTrackerNames { get; } = null;

    public string Key { get; }

    public string GetKey => Key;

    /// <summary>
    /// Returns an array of tuples that specify a range factor and color to render for a range of values.  The <param name="startValue"></param> specifies the smallest (or start) value of the range.  Ranges must be sorted in
    /// descending order.  This sorting is validated once upon first usage.  If the value is larger than the first range, the first range will match.  If the value is smaller than the last range specified, the
    /// <see cref="DefaultText"/> and <see cref="DefaultColor"/> will be used.  Duplicate startValues cannot be used and will fail the sort validation.
    /// 
    /// The factor
    /// </summary>
    public (int percentage, string? text, ColorEnum color)[] Ranges { get; }

    /// <summary>
    /// Returns the color for the <see cref="Text"/> to be rendered in when none of the ranges apply.  Returns the color white, by default.
    /// </summary>
    private ColorEnum DefaultColor { get; } = ColorEnum.White;

    public string MaxIntValueName { get; }
    public IIntValue MaxIntValue { get; private set; }

    public string IntValueName { get; }
    public IIntValue IntValue { get; private set; }

    public void Bind()
    {
        ChangeTrackers = Game.SingletonRepository.GetNullable<IChangeTracker>(ChangeTrackerNames);
        Justification = Game.SingletonRepository.Get<Justification>(JustificationName);
        IntValue = Game.SingletonRepository.Get<IIntValue>(IntValueName);
        MaxIntValue = Game.SingletonRepository.Get<IIntValue>(MaxIntValueName);
    }

    private void ValidateRangeSorting()
    {
        if (!_sortValidated)
        {
            int? previousMaxValue = null;
            foreach ((int percentage, string? text, ColorEnum color) in Ranges)
            {
                if (previousMaxValue != null && percentage >= previousMaxValue.Value)
                {
                    throw new Exception($"The ranges specified for the {GetType().Name} are not sorted property.");
                }
                previousMaxValue = percentage;
            }
            _sortValidated = true;
        }
    }

    public string Text => _value;

    public ColorEnum Color => _color;

    public string ToJson()
    {
        MaxRangedWidgetGameConfiguration rangedWidgetGameConfiguration = new MaxRangedWidgetGameConfiguration()
        {
            Key = Key,
            Ranges = Ranges,
            IntValueName = IntValueName,
            DefaultColor = DefaultColor,
            X = X,
            Y = Y,
            Width = Width,
            JustificationName = JustificationName,
            ChangeTrackerNames = ChangeTrackerNames,
            MaxIntValueName = MaxIntValueName,
        };
        return JsonSerializer.Serialize(rangedWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }

    public override void Update()
    {
        // Now that we need to check the ranges, validate that the ranges are properly sorted in descending order.  We only do this once.
        ValidateRangeSorting();

        // Grab a copy of the value and max value so that we do not retrieve it for every range.
        int intValue = IntValue.IntValue;
        string intTextValue = intValue.ToString();
        int maxValue = MaxIntValue.IntValue;

        // Apply the default text and color.
        ColorEnum foundColor = DefaultColor;

        // Scan the ranges for the first valid range.
        foreach ((int percentage, string? text, ColorEnum color) in Ranges)
        {
            (int quotient, int remainder) = Math.DivRem(maxValue * percentage, 100);
            if (remainder > 0)
            {
                quotient++;
            }

            // Check the value with the percentage of the maximum value.
            if (intValue >= quotient) // We are rounding up so that small max values wont match percentages resulting in a 0 from a round down
            {
                if (text != null)
                {
                    intTextValue = text;
                }
                else
                {
                    intTextValue = intValue.ToString();
                }
                foundColor = color;
                break;
            }
        }


        // Check to see if the value has changed or color has changed.
        if (foundColor != _color || intTextValue != _value)
        {
            // Update the exposed value and color.
            _value = intTextValue;
            _color = foundColor;

            Invalidate();
        }

        base.Update();
    }

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
    /// Paint the widget on the screen.  No checks or resets of the validation status are or should be performed during this method.
    /// </summary>
    protected override void Paint()
    {
        string justifiedText = Text;
        justifiedText = Justification.Format(justifiedText, Width ?? justifiedText.Length);
        Game.Screen.Print(Color, justifiedText, Y, X);
    }
}
