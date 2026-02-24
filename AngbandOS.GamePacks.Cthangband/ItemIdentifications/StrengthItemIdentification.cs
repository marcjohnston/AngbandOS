namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class StrengthItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(StrengthItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your strength." };
    }
}