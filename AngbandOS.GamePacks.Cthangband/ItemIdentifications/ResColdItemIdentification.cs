namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResColdItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResColdAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to cold." };
    }
}