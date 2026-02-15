namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class HeavyCurseBooleanGetItemProperty : GetItemProperty<bool>
{
    public HeavyCurseBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.HeavyCurse;
    }
}