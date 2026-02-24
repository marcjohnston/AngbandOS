namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class BlessedSwordsOfValueItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BlessedAttribute), true),
    };
}