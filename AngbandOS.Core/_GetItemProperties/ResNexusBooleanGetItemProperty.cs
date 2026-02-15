namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResNexusBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResNexusBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResNexus;
    }
}