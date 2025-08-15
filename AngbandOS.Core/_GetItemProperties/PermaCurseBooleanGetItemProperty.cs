namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class PermaCurseBooleanGetItemProperty : GetItemProperty<bool>
{
    public PermaCurseBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.PermaCurse);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.PermaCurse;
    }
}