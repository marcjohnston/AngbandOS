namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class HeavilyCursedItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool?[] DesiredValue)[]? BoolAttributeFilterBindings => new (string, bool?[])[] { (nameof(IsCursedAttribute), new bool?[] { true }), (nameof(HeavyCurseAttribute), new bool?[] { true }) };
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(PermaCurseAttribute), false) };
    }
}