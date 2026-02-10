namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ImColdBooleanGetItemProperty : GetItemProperty<bool>
{
    public ImColdBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AttributeEnum.ImCold);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ImCold;
    }
}