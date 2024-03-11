// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.PropertyFormatters;

[Serializable]
internal abstract class RangedIntFormatter : IntFormatter
{
    private bool _sortValidated = false;

    protected RangedIntFormatter(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns a tuple with the text to be associated with all values less than or equal to the maxValue specified.  If a value is larger than all values, then the <see cref="DefaultText"/> 
    /// value is returned.  The tuples must be sorted by the maxValue in ascending order.
    /// </summary>
    public abstract (int maxValue, string text)[] Ranges { get; }

    /// <summary>
    /// Returns the text to be returned, when none of the ranges apply.
    /// </summary>
    protected abstract string DefaultText { get; }

    public override string Format(int value, int width)
    {
        // Validate that the ranges are properly sorted.  Only do this once.
        if (!_sortValidated)
        {
            int? previousMaxValue = null;
            foreach ((int maxValue, string text) in Ranges)
            {
                if (previousMaxValue != null && previousMaxValue.Value > maxValue)
                {
                    throw new Exception($"The ranges specified for the {GetType().Name} are not sorted property.");
                }
            }
            _sortValidated = true;
        }

        foreach ((int maxValue, string text) in Ranges)
        {
            if (value <= maxValue)
            {
                return text.PadRight(width, ' ');
            }
        }
        return DefaultText.PadRight(width, ' ');
    }
}
