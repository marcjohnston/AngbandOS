namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResNetherBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResNetherBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AttributeEnum.ResNether);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResNether;
    }
}