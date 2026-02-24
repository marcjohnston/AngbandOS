namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayTrollItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(SlayTrollItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is especially deadly against trolls." };
    }
}