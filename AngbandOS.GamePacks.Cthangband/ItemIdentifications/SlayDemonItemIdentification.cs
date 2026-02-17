namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayDemonItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayDemonAttribute), true) };
        public override string[] EffectDescription => new string[] { "It strikes at demons with holy wrath." };
    }
}