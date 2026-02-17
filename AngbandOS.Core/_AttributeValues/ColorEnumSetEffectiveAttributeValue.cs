// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ColorEnumSetEffectiveAttributeValue : SetEffectiveAttributeValue<ColorEnum>
{
    public ColorEnumSetEffectiveAttributeValue(Game game, Attribute attribute, ColorEnum defaultColor) : base(game, attribute, defaultColor) { }

    public override EffectiveAttributeValue Clone()
    {
        ColorEnumSetEffectiveAttributeValue clone = new ColorEnumSetEffectiveAttributeValue(Game, Attribute, InitialValue);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }
    public override string RenderForItemIdentification => Get().ToString();

    /// <summary>
    /// Computes a value to append to the modifiers so that the effective value equals the specified value.
    /// </summary>
    /// <param name="value"></param>
    public void Set(ColorEnum color)
    {
        _attributeModifiers.Add(("", color));
    }
}