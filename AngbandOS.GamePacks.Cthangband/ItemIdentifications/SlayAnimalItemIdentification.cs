namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayAnimalItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayAnimalAttribute), true) };
        public override string[] EffectDescription => new string[] { "It is especially deadly against natural creatures." };
    }
}