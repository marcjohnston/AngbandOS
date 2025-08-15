namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ShFireBooleanGetItemProperty : GetItemProperty<bool>
{
    public ShFireBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.ShFire);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ShFire;
    }
}