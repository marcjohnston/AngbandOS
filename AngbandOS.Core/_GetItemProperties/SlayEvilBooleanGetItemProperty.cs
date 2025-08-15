namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SlayEvilBooleanGetItemProperty : GetItemProperty<bool>
{
    public SlayEvilBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.SlayEvil);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SlayEvil;
    }
}