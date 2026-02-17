namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RegenItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(RegenAttribute), true) };
        public override string[] EffectDescription => new string[] { "It speeds your regenerative powers." };
    }
}