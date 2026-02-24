namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustConItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(SustConItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It sustains your constitution." };
    }
}