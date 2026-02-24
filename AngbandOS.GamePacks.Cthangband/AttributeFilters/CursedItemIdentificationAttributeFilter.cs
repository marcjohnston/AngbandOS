namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class CursedItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool?[] DesiredValue)[]? BoolAttributeFilterBindings => new (string, bool?[])[] { (nameof(IsCursedAttribute), new bool?[] { true }), (nameof(HeavyCurseAttribute), new bool?[] { false, null }) };
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(PermaCurseAttribute), false) };
    }
}