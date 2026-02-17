namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayEvilItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayEvilAttribute), true) };
        public override string[] EffectDescription => new string[] { "It fights against evil with holy fury." };
    }
}