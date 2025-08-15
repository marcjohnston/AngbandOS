namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class DrainExpBooleanGetItemProperty : GetItemProperty<bool>
{
    public DrainExpBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(EffectivePropertySet.DrainExp);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.DrainExp;
    }
}