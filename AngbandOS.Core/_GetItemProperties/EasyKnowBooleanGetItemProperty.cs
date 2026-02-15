namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class EasyKnowBooleanGetItemProperty : GetItemProperty<bool>
{
    public EasyKnowBooleanGetItemProperty(Game game) : base(game) { }

    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.EasyKnow;
    }
}