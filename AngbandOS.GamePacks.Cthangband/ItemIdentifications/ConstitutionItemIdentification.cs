namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ConstitutionItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(ConstitutionAttribute), 1, null) };
        public override string[] EffectDescription => new string[] { "It affects your constitution." };
    }
}