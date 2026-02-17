namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class AttacksItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(AttacksAttribute), 1, null) };
        public override string[] EffectDescription => new string[] { "It affects your attack speed." };
    }
}