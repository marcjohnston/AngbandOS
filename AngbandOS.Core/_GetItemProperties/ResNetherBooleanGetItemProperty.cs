namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResNetherBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResNetherBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResNether;
    }
}