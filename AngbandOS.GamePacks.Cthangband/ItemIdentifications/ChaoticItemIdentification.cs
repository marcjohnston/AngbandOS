namespace AngbandOS.GamePacks.Cthangband
{
    public class ChaoticItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ChaoticItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It produces chaotic effects." };
    }
}