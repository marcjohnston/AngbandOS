namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class BrandPoisBooleanGetItemProperty : GetItemProperty<bool>
{
    public BrandPoisBooleanGetItemProperty(Game game) : base(game) { }

    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.BrandPois;
    }
}