namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class StrengthItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(StrengthAttribute), 1, null) };
        public override string[] EffectDescription => new string[] { "It affects your strength." };
    }
}