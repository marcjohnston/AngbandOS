namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ImElecBooleanGetItemProperty : GetItemProperty<bool>
{
    public ImElecBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ImElec;
    }
}