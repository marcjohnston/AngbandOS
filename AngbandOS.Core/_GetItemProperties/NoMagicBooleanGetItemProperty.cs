namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class NoMagicBooleanGetItemProperty : GetItemProperty<bool>
{
    public NoMagicBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.NoMagic);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.NoMagic;
    }
}