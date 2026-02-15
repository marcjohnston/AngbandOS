namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResDarkBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResDarkBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResDark;
    }
}