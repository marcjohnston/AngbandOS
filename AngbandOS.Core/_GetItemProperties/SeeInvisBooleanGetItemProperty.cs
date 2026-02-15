namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SeeInvisBooleanGetItemProperty : GetItemProperty<bool>
{
    public SeeInvisBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SeeInvis;
    }
}