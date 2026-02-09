// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class NullableReferenceAttributeValue<T> : SetEffectiveAttributeValue<T?>
{
    public NullableReferenceAttributeValue(Game game, T? defaultValue) : base(game, defaultValue) { }

    public override EffectiveAttributeValue Clone()
    {
        NullableReferenceAttributeValue<T> clone = new NullableReferenceAttributeValue<T>(Game, InitialValue);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }

    /// <summary>
    /// Computes a value to append to the modifiers so that the effective value equals the specified value.
    /// </summary>
    /// <param name="value"></param>
    public void Set(T? value)
    {
        _attributeModifiers.Add(("", value));
    }
}
