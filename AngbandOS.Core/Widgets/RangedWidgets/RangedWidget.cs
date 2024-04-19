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

    protected RangedWidget(Game game) : base(game)
    {
        _text = DefaultText;
        _color = DefaultColor;
    }

    /// <summary>
    /// Returns an array of tuples that specify the text and color to render for a range of values.  The <paramref name="startValue"/> element specifies the smallest (or start) value of the range.  Ranges must be sorted in
    /// descending order (from the largest value to the smallest).  This sorting is validated once upon first usage.  If the value is larger than the first range, the first range will match.  If the value is smaller than the last range specified, the
    /// <see cref="DefaultText"/> and <see cref="DefaultColor"/> will be used.  Duplicate <paramref name="startValue"/> element cannot be used and will fail the sort validation.
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

    public override void Update()
    {
        // Check to see if the see if the underlying value changed.
        if (IntChangeTracking.IsChanged)
        {
            // Now that we need to check the ranges, validate that the ranges are properly sorted in descending order.  We only do this once.
            ValidateRangeSorting();

            // Grab a copy of the value so that we do not retrieve it for every range.
            int intValue = IntChangeTracking.Value;

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
        }

        base.Update();
    }
}
