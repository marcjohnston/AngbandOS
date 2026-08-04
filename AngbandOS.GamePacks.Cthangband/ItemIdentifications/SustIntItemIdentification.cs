namespace AngbandOS.GamePacks.Cthangband
{
    public class SustIntItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SustIntItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It sustains your intelligence." };
    }
}