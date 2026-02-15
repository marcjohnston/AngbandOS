namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SustDexBooleanGetItemProperty : GetItemProperty<bool>
{
    public SustDexBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SustDex;
    }
}