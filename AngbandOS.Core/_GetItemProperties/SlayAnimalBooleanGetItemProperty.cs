namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SlayAnimalBooleanGetItemProperty : GetItemProperty<bool>
{
    public SlayAnimalBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.SlayAnimal);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SlayAnimal;
    }
}