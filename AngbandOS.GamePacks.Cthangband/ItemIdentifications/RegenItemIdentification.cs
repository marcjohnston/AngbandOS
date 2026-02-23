namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RegenItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool?[] DesiredValue)[]? BoolAttributeFilterBindings => new (string AttributeKey, bool?[] DesiredValue)[] { (nameof(RegenAttribute), new bool?[] { true }) };
        public override string[] EffectDescription => new string[] { "It speeds your regenerative powers." };
    }
}