namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class PermanentCursedItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool?[] DesiredValue)[]? BoolAttributeFilterBindings => new (string, bool?[])[] { (nameof(IsCursedAttribute), new bool?[] { true }) };
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(PermaCurseAttribute), true) };
    }
}