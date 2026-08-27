namespace AngbandOS.GamePacks.Cthangband;
public class CanSlayAndFalseSlayDemonItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(SlayDemonAttribute), false),
    };
}