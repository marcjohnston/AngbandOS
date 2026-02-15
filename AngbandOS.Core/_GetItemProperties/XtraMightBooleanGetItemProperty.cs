namespace AngbandOS.Core.GetItemProperties;
[Serializable]
internal class XtraMightBooleanGetItemProperty : GetItemProperty<bool>
{
    public XtraMightBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.XtraMight;
    }
}
