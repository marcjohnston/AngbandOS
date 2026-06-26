namespace AngbandOS.Core.GetItemProperties;
internal class HeavyCurseBooleanGetItemProperty : GetItemProperty<bool>
{
    public HeavyCurseBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectiveAttributeSet.HeavyCurse;
    }
}