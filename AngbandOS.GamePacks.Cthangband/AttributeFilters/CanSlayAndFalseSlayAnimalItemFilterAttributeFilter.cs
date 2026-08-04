namespace AngbandOS.GamePacks.Cthangband;
public class CanSlayAndFalseSlayAnimalItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(SlayAnimalAttribute), false),
    };
}