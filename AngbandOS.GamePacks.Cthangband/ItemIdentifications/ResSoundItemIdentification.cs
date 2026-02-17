namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResSoundItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResSoundAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to sound." };
    }
}