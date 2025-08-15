namespace AngbandOS.Core.GetItemProperties;

[Serializable]
internal class XtraShotsBooleanGetItemProperty : GetItemProperty<bool>
{
    public XtraShotsBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.XtraShots);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.XtraShots;
    }
}