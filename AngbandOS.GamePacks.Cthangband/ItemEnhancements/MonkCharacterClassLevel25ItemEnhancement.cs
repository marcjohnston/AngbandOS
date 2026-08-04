namespace AngbandOS.GamePacks.Cthangband;

public class MonkCharacterClassLevel25ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
    };
}
