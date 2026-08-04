namespace AngbandOS.GamePacks.Cthangband
{
    public class SustConItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SustConItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It sustains your constitution." };
    }
}