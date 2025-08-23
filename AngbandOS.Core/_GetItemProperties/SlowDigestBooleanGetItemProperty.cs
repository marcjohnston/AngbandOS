namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SlowDigestBooleanGetItemProperty : GetItemProperty<bool>
{
    public SlowDigestBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.SlowDigest);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SlowDigest;
    }
}