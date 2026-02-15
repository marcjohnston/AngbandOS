namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SustConBooleanGetItemProperty : GetItemProperty<bool>
{
    public SustConBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SustCon;
    }
}