namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustDexItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SustDexAttribute), true) };
        public override string[] EffectDescription => new string[] { "It sustains your dexterity." };
    }
}