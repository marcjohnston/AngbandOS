namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayDemonItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SlayDemonItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It strikes at demons with holy wrath." };
    }
}