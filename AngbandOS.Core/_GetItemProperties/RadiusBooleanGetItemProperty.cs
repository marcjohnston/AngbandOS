namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class RadiusBooleanGetItemProperty : GetItemProperty<bool>
{
    public RadiusBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AggravateAttribute);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Radius > 0;
    }
}