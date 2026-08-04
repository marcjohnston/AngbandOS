namespace AngbandOS.GamePacks.Cthangband;
public class CanSlayAndFalseSlayUndeadItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(SlayUndeadAttribute), false),
    };
}