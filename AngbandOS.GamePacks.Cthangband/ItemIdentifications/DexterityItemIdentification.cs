namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DexterityItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(DexterityAttribute), 1, null) };
        public override string[] EffectDescription => new string[] { "It affects your dexterity." };
    }
}