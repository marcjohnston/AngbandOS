namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class InfravisionItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(InfravisionAttribute), 1, null) };
        public override string[] EffectDescription => new string[] { "It affects your infravision." };
    }
}