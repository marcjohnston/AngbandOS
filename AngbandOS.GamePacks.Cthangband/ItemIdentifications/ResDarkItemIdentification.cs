namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResDarkItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResDarkItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to dark." };
    }
}