// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class NullableReferenceSetEffectiveAttributeValue<T> : SetEffectiveAttributeValue<T?>
{
    public NullableReferenceSetEffectiveAttributeValue(Game game, Attribute attribute, T? defaultValue) : base(game, attribute, defaultValue) { }

    /// <summary>
    /// Computes a value to append to the modifiers so that the effective value equals the specified value.
    /// </summary>
    /// <param name="value"></param>
    public void Set(T? value)
    {
        _attributeModifiers.Add(("", value));
    }
}
