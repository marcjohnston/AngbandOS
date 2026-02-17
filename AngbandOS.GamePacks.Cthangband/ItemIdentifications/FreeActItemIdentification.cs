namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FreeActItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(FreeActAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides immunity to paralysis." };
    }
}