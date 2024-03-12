// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class RangedIntWidget : IntWidget
{
    private bool _sortValidated = false;

    protected RangedIntWidget(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns a tuple with the text to be associated with all values less than or equal to the maxValue specified.  If a value is larger than all values, then the <see cref="DefaultText"/> 
    /// value is returned.  The tuples must be sorted by the maxValue in ascending order.
    /// </summary>
    public abstract (int maxValue, string text, ColorEnum color)[] Ranges { get; }

    /// <summary>
    /// Returns the text to be returned, when none of the ranges apply.
    /// </summary>
    protected abstract string DefaultText { get; }

    protected abstract ColorEnum DefaultColor { get; }

    private string _text;
    private ColorEnum _color;

    public override string Text => _text;

    public override ColorEnum Color => _color;

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

            // Now that we need to check the ranges, validate that the ranges are properly sorted.  We only do this once.
            if (!_sortValidated)
            {
                int? previousMaxValue = null;
                foreach ((int maxValue, string text, ColorEnum color) in Ranges)
                {
                    if (previousMaxValue != null && previousMaxValue.Value > maxValue)
                    {
                        throw new Exception($"The ranges specified for the {GetType().Name} are not sorted property.");
                    }
                }
                _sortValidated = true;
            }

            // Grab a copy of the value so that we do not retrieve it for every range.
            int intValue = IntChangeTrackable.Value;
            (string text, ColorEnum color)? found = null;

            foreach ((int maxValue, string text, ColorEnum color) in Ranges)
            {
                if (intValue <= maxValue)
                {
                    found = (text, color);
                    break;
                }
            }

            // Check to see if we need to apply the default value.
            if (found == null)
            {
                found = (DefaultText, DefaultColor);
            }

            // Check to see if the value has changed.
            if (found.Value.text != _text || found.Value.color != _color)
            {
                _text = found.Value.text;
                _color = found.Value.color;
                return true;
            }
            return false;
        }
    }
}
