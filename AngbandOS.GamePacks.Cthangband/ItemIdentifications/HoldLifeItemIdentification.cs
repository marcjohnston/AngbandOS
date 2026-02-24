namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class HoldLifeItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(HoldLifeItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to life draining." };
    }
}