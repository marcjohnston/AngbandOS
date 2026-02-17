namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class PermanentCursedItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool? DesiredValue)[]? BoolAttributeFilterBindings => new (string, bool?)[] { (nameof(IsCursedAttribute), true) };
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(PermaCurseAttribute), true) };
        public override string[] EffectDescription => new string[] { "It is permanently cursed." };
    }
}