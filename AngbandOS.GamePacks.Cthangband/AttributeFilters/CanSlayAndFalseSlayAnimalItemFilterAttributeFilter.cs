namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CanSlayAndFalseSlayAnimalItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(SlayAnimalAttribute), false),
    };
}