namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SustChaBooleanGetItemProperty : GetItemProperty<bool>
{
    public SustChaBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AttributeEnum.SustCha);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SustCha;
    }
}