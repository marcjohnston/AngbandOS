namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ImpactBooleanGetItemProperty : GetItemProperty<bool>
{
    public ImpactBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AggravateAttribute);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Impact;
    }
}