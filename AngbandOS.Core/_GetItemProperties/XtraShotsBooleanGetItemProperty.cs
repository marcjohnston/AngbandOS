namespace AngbandOS.Core.GetItemProperties;

[Serializable]
internal class XtraShotsBooleanGetItemProperty : GetItemProperty<bool>
{
    public XtraShotsBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.XtraShots);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.XtraShots;
    }
}