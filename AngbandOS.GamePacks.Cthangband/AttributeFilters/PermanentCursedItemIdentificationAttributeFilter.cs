namespace AngbandOS.GamePacks.Cthangband
{
    public class PermanentCursedItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] 
        {
            (nameof(IsCursedAttribute), true),
            (nameof(PermaCurseAttribute), true) 
        };
    }
}