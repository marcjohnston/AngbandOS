namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class BrandColdBooleanGetItemProperty : GetItemProperty<bool>
{
    public BrandColdBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(EffectivePropertySet.BrandCold);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.BrandCold;
    }
}