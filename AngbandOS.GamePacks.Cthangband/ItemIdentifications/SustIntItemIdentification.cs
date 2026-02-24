namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustIntItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(SustIntItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It sustains your intelligence." };
    }
}