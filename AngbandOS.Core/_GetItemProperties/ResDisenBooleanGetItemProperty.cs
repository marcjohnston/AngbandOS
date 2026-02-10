namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResDisenBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResDisenBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AttributeEnum.ResDisen);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResDisen;
    }
}