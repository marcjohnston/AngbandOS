namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class FreeActItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(FreeActItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides immunity to paralysis." };
    }
}