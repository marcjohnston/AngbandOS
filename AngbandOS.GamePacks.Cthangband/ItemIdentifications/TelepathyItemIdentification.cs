namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class TelepathyItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(TelepathyItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It gives telepathic powers." };
    }
}