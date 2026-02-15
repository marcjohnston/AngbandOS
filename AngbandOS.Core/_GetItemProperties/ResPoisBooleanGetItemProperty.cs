namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResPoisBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResPoisBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResPois;
    }
}