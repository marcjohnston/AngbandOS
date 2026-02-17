namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustStrItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SustStrAttribute), true) };
        public override string[] EffectDescription => new string[] { "It sustains your strength." };
    }
}