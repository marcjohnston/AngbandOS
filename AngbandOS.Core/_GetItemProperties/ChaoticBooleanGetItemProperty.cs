namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ChaoticBooleanGetItemProperty : GetItemProperty<bool>
{
    public ChaoticBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(AttributeEnum.Chaotic);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Chaotic;
    }
}