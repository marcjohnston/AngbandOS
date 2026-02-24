namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FeatherItemIdentification : ItemIdentificationGameConfiguration
    {
        public override string AttributesFilterBindingKey => nameof(FeatherItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It allows you to levitate." };
    }
}