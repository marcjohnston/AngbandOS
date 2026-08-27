namespace AngbandOS.GamePacks.Cthangband;
public class CanSlayAndFalseSlayEvilItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(SlayEvilAttribute), false),
    };
}