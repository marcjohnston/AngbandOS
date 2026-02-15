namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SustIntBooleanGetItemProperty : GetItemProperty<bool>
{
    public SustIntBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SustInt;
    }
}