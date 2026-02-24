namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DreadCurseItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(DreadCurseAttribute), true) };
    }
}