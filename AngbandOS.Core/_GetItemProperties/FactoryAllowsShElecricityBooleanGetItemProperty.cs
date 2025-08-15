namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class FactoryAllowsShElecricityBooleanGetItemProperty : GetItemProperty<bool>
{
    public FactoryAllowsShElecricityBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.CanProvideSheathOfElectricity);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.CanProvideSheathOfElectricity;
    }
}