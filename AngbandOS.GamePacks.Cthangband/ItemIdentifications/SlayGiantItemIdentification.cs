namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayGiantItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayGiantAttribute), true) };
        public override string[] EffectDescription => new string[] { "It is especially deadly against giants." };
    }
}