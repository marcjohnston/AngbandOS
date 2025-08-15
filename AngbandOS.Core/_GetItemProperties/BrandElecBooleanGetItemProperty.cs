namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class BrandElecBooleanGetItemProperty : GetItemProperty<bool>
{
    public BrandElecBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(EffectivePropertySet.BrandElec);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.BrandElec;
    }
}