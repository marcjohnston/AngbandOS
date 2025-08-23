namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SlayEvilBooleanGetItemProperty : GetItemProperty<bool>
{
    public SlayEvilBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.SlayEvil);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SlayEvil;
    }
}