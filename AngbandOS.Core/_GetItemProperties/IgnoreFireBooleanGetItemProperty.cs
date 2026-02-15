namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class IgnoreFireBooleanGetItemProperty : GetItemProperty<bool>
{
    public IgnoreFireBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.IgnoreFire;
    }
}