namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SlayUndeadBooleanGetItemProperty : GetItemProperty<bool>
{
    public SlayUndeadBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SlayUndead;
    }
}