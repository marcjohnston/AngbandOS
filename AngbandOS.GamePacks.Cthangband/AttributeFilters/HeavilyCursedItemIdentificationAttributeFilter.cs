namespace AngbandOS.GamePacks.Cthangband
{
    public class HeavilyCursedItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] 
        {
            (nameof(IsCursedAttribute), true),
            (nameof(HeavyCurseAttribute), true),
            (nameof(PermaCurseAttribute), false) 
        };
    }
}