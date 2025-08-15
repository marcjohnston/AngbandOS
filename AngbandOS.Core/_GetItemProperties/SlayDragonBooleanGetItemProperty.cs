namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SlayDragonBooleanGetItemProperty : GetItemProperty<bool>
{
    public SlayDragonBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.SlayDragon);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SlayDragon > 1;
    }
}