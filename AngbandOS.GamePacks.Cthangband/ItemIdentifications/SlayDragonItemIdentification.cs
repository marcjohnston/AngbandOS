namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayDragonItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SlayDragonAttribute), 1, 2) };
        public override string[] EffectDescription => new string[] { "It is especially deadly against dragons." };
    }
}