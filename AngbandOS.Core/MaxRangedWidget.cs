﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class MaxRangedWidget : TextWidget
{
    private bool _sortValidated = false;
    private string _value;
    private ColorEnum _color;

    protected MaxRangedWidget(Game game) : base(game)
    {
        _color = DefaultColor;
    }

    /// <summary>
    /// Returns an array of tuples that specify a range factor and color to render for a range of values.  The <param name="startValue"></param> specifies the smallest (or start) value of the range.  Ranges must be sorted in
    /// descending order.  This sorting is validated once upon first usage.  If the value is larger than the first range, the first range will match.  If the value is smaller than the last range specified, the
    /// <see cref="DefaultText"/> and <see cref="DefaultColor"/> will be used.  Duplicate startValues cannot be used and will fail the sort validation.
    /// 
    /// The factor
    /// </summary>
    public abstract (int percentage, string? text, ColorEnum color)[] Ranges { get; }

    /// <summary>
    /// Returns the color for the <see cref="Text"/> to be rendered in when none of the ranges apply.  Returns the color white, by default.
    /// </summary>
    protected virtual ColorEnum DefaultColor => ColorEnum.White;

    public abstract string MaxIntValueName { get; }
    public IIntValue MaxIntValue { get; private set; }

    public abstract string IntValueName { get; }
    public IIntValue IntValue { get; private set; }

    public override void Bind()
    {
        base.Bind();
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

    public sealed override string Text => _value;

    public sealed override ColorEnum Color => _color;

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
}
