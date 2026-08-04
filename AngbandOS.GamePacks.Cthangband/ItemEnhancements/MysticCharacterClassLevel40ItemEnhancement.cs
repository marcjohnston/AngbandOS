
namespace AngbandOS.GamePacks.Cthangband;

public class MysticCharacterClassLevel40ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(TelepathyAttribute), "true"),
    };
}
