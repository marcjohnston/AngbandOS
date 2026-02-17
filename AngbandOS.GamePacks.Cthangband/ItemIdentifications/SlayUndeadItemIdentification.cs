namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayUndeadItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayUndeadAttribute), true) };
        public override string[] EffectDescription => new string[] { "It strikes at undead with holy wrath." };
    }
}