namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class AttacksItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(AttacksItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your attack speed." };
    }
}