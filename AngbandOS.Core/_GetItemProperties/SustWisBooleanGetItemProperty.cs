namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SustWisBooleanGetItemProperty : GetItemProperty<bool>
{
    public SustWisBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AttributeEnum.SustWis);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SustWis;
    }
}