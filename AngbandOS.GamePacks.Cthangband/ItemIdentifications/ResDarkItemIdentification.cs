namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResDarkItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResDarkAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to dark." };
    }
}