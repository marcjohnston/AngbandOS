namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class Vorpal1InChanceItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(Vorpal1InChanceAttribute), 1, null) };
        public override string[] EffectDescription => new string[] { "It is very sharp and can cut your foes." };
    }
}