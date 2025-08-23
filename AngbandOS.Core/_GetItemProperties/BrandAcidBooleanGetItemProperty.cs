namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class BrandAcidBooleanGetItemProperty : GetItemProperty<bool>
{
    public BrandAcidBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(EffectiveAttributeSet.BrandAcid);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.BrandAcid;
    }
}