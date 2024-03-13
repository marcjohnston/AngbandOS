// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class RangedWidget : IntWidget
{
    private bool _sortValidated = false;
    private string _text;
    private ColorEnum _color;

    protected RangedWidget(SaveGame saveGame) : base(saveGame)
    {
        _text = DefaultText;
        _color = DefaultColor;
    }

    /// <summary>
    /// Returns a tuple with the text and color to be associated with all values less than or equal to the maxValue specified.  If the value is smaller than all values, then the <see cref="DefaultText"/> 
    /// value and <see cref="DefaultColor"/> is used.  The tuples must be sorted by the startValue in descending order.  The sorting is validated once upon first usage.  Duplicate startValues
    /// cannot be used and will fail the sort validation.
    /// </summary>
    public abstract (int startValue, string textToRender, ColorEnum color)[] Ranges { get; }

    /// <summary>
    /// Returns the text to be rendered, when none of the ranges apply.  Returns an empty string, by default.
    /// </summary>
    protected virtual string DefaultText => "";

    /// <summary>
    /// Returns the color for the <see cref="Text"/> to be rendered in when none of the ranges apply.  Returns the color white, by default.
    /// </summary>
    protected virtual ColorEnum DefaultColor => ColorEnum.White;

    public sealed override string Text => _text;

    public sealed override ColorEnum Color => _color;

    private void ValidateRangeSorting()
    {
        if (!_sortValidated)
        {
            int? previousMaxValue = null;
            foreach ((int startValue, string text, ColorEnum color) in Ranges)
            {
                if (previousMaxValue != null && startValue >= previousMaxValue.Value)
                {
                    throw new Exception($"The ranges specified for the {GetType().Name} are not sorted property.");
                }
                previousMaxValue = startValue;
            }
            _sortValidated = true;
        }
    }

    protected override bool ValueChanged
    {
        get
        {
            // Check to see if the see if the underlying value changed.
            if (!base.ValueChanged)
            {
                // It did not, then no reason to check the ranges.
                return false;
            }

            // Now that we need to check the ranges, validate that the ranges are properly sorted in descending order.  We only do this once.
            ValidateRangeSorting();

            // Grab a copy of the value so that we do not retrieve it for every range.
            int intValue = IntChangeTrackable.Value;

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

                return true;
            }
            return false;
        }
    }
}
