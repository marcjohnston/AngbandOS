namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SustStrBooleanGetItemProperty : GetItemProperty<bool>
{
    public SustStrBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.SustStr);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SustStr;
    }
}