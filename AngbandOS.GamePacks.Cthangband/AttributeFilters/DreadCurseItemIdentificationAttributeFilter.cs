namespace AngbandOS.GamePacks.Cthangband
{
    public class DreadCurseItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[] { (nameof(DreadCurseAttribute), true) };
    }
}