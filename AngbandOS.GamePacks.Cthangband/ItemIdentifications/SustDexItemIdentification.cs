namespace AngbandOS.GamePacks.Cthangband
{
    public class SustDexItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SustDexItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It sustains your dexterity." };
    }
}