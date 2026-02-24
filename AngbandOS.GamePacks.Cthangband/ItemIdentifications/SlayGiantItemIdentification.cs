namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayGiantItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SlayGiantItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is especially deadly against giants." };
    }
}