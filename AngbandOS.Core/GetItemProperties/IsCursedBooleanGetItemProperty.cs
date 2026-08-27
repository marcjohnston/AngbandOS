namespace AngbandOS.Core.GetItemProperties;
internal class IsCursedBooleanGetItemProperty : GetItemProperty<bool>
{
    public IsCursedBooleanGetItemProperty(Game game) : base(game) { }

    public override bool Get(Item item)
    {
        return item.EffectiveAttributeSet.IsCursed;
    }
}