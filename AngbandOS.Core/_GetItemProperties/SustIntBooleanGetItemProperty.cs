namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SustIntBooleanGetItemProperty : GetItemProperty<bool>
{
    public SustIntBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AttributeEnum.SustInt);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SustInt;
    }
}