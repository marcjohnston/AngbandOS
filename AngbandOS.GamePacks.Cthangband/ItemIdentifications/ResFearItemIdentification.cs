namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResFearItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResFearAttribute), true) };
        public override string[] EffectDescription => new string[] { "It makes you completely fearless." };
    }
}