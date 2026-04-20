// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ActivationEffectiveAttributeValue : NullableReferenceSetEffectiveAttributeValue<Activation>
{
    public ActivationEffectiveAttributeValue(Game game, Attribute attribute) : base(game, attribute, null) { }
    public override string RenderForItemIdentification => Get()?.Description ?? "nothing";
    public override AttributeValue ToReadOnly() => new ActivationReadOnlyAttributeValue(Get());
    public override EffectiveAttributeValue Clone()
    {
        ActivationEffectiveAttributeValue clone = new ActivationEffectiveAttributeValue(Game, Attribute);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }
    public override void Merge(AttributeValue value)
    {
        ActivationReadOnlyAttributeValue setEffectiveAttributeValue = (ActivationReadOnlyAttributeValue)value;
        _attributeModifiers.Add(("", setEffectiveAttributeValue.Value));
    }

    public override void Merge(string key, AttributeValue value)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Invalid key specified for enhancements.");
        }
        ActivationReadOnlyAttributeValue setEffectiveAttributeValue = (ActivationReadOnlyAttributeValue)value;
        _attributeModifiers.Add((key, setEffectiveAttributeValue.Value));
    }
}
