namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SlayDragonBooleanGetItemProperty : GetItemProperty<bool>
{
    public SlayDragonBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AggravateAttribute);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SlayDragon > 1;
    }
}