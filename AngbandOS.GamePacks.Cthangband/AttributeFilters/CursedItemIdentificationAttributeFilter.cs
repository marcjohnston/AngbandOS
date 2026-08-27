namespace AngbandOS.GamePacks.Cthangband
{
    public class CursedItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] 
        {
            (nameof(IsCursedAttribute), true),
            (nameof(HeavyCurseAttribute), false),
            (nameof(PermaCurseAttribute), false) 
        };
    }
}