namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SlayGiantBooleanGetItemProperty : GetItemProperty<bool>
{
    public SlayGiantBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.SlayGiant);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SlayGiant;
    }
}