namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class BrandFireBooleanGetItemProperty : GetItemProperty<bool>
{
    public BrandFireBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(EffectivePropertySet.BrandFire);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.BrandFire;
    }
}