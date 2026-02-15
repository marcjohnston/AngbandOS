namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class FactoryAllowsShFireBooleanGetItemProperty : GetItemProperty<bool>
{
    public FactoryAllowsShFireBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.CanProvideSheathOfFire;
    }
}