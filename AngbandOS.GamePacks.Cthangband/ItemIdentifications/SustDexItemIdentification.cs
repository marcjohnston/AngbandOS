namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustDexItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SustDexItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It sustains your dexterity." };
    }
}