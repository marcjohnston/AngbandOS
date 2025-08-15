namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ShElecBooleanGetItemProperty : GetItemProperty<bool>
{
    public ShElecBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.ShElec);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ShElec;
    }
}