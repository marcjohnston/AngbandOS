namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CanSlayAndFalseSlayDemonItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(SlayDemonAttribute), false),
    };
}