namespace AngbandOS.GamePacks.Cthangband;

public class YeekRaceLevel20ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ImAcidAttribute), "true")
    };
}
