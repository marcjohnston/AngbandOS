namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class BlessedSwordsOfValueItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BlessedAttribute), true),
    };
}