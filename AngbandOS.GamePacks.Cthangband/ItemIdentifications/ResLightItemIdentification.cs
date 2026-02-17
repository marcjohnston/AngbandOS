namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResLightItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResLightAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to light." };
    }
}