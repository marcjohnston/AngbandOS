namespace AngbandOS.GamePacks.Cthangband;
public class BlessedSwordsOfValueItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(BlessedAttribute), true),
    };
}