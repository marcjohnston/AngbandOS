namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResSoundBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResSoundBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.ResSound);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResSound;
    }
}