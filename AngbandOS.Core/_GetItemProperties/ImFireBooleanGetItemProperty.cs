namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ImFireBooleanGetItemProperty : GetItemProperty<bool>
{
    public ImFireBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.ImFire);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ImFire;
    }
}