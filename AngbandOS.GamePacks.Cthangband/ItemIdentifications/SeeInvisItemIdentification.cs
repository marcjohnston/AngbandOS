namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SeeInvisItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SeeInvisItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It allows you to see invisible monsters." };
    }
}