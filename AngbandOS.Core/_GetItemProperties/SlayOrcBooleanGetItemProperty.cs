namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SlayOrcBooleanGetItemProperty : GetItemProperty<bool>
{
    public SlayOrcBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SlayOrc;
    }
}