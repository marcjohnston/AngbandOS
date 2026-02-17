namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayDragonBaneItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SlayDragonAttribute), 3, null) };
        public override string[] EffectDescription => new string[] { "It is a great bane of dragons." };
    }
}