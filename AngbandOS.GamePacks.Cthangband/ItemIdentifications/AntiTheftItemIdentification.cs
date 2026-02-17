namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class AntiTheftItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(AntiTheftAttribute), true) };
        public override string[] EffectDescription => new string[] { "It prevents theft from your purse and pack." };
    }
}