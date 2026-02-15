namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SlayDemonBooleanGetItemProperty : GetItemProperty<bool>
{
    public SlayDemonBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SlayDemon;
    }
}