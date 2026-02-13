namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class IsCursedBooleanGetItemProperty : GetItemProperty<bool>
{
    public IsCursedBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(AggravateAttribute);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.IsCursed;
    }
}