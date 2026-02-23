// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class BoolSetEffectiveAttributeValue : SetEffectiveAttributeValue<bool?>
{
    public BoolSetEffectiveAttributeValue(Game game, Attribute attribute, bool? defaultValue) : base(game, attribute, defaultValue) { }

    public override EffectiveAttributeValue Clone()
    {
        BoolSetEffectiveAttributeValue clone = new BoolSetEffectiveAttributeValue(Game, Attribute, InitialValue);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }
    public override string RenderForItemIdentification => Get().ToString();

    /// <summary>
    /// Computes a value to append to the modifiers so that the effective value equals the specified value.
    /// </summary>
    /// <param name="value"></param>
    public void Set(bool value)
    {
        _attributeModifiers.Add(("", value));
    }

    /// <summary>
    /// Computes a value to append to the modifiers so that the effective value equals the specified value.
    /// </summary>
    /// <param name="value"></param>
    public void Set()
    {
        _attributeModifiers.Add(("", true));
    }

    /// <summary>
    /// Appends a false modifier to the list of modifiers--effectively making the attribute value false.
    /// </summary>
    public void Reset()
    {
        _attributeModifiers.Add(("", false));
    }
    public bool IsTrue
    {
        get
        {
            bool? value = Get();
            return value.HasValue && value.Value;
        }
    }
}
