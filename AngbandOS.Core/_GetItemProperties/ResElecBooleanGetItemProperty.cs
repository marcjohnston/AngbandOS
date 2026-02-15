namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResElecBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResElecBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResElec;
    }
}