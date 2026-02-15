namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResShardsBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResShardsBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResShards;
    }
}