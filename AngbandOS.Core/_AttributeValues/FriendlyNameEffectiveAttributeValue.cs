// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class FriendlyNameEffectiveAttributeValue : NullableReferenceSetEffectiveAttributeValue<string> 
{
    public FriendlyNameEffectiveAttributeValue(Game game, Attribute attribute) : base(game, attribute, null) { }
    public override EffectiveAttributeValue Clone()
    {
        FriendlyNameEffectiveAttributeValue clone = new FriendlyNameEffectiveAttributeValue(Game, Attribute);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }
    public override string RenderForItemIdentification => "";
    public override AttributeValue ToReadOnly() => new NullableStringReadOnlyAttributeValue(Get());
    public override void Merge(AttributeValue value)
    {
        NullableStringReadOnlyAttributeValue setEffectiveAttributeValue = (NullableStringReadOnlyAttributeValue)value;
        _attributeModifiers.Add(("", setEffectiveAttributeValue.Value));
    }

    public override void Merge(string key, AttributeValue value)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Invalid key specified for enhancements.");
        }
        NullableStringReadOnlyAttributeValue setEffectiveAttributeValue = (NullableStringReadOnlyAttributeValue)value;
        _attributeModifiers.Add((key, setEffectiveAttributeValue.Value));
    }
}