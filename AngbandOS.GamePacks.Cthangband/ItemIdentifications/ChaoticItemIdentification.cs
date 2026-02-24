namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ChaoticItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ChaoticItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It produces chaotic effects." };
    }
}