
namespace AngbandOS.GamePacks.Cthangband;

public class MindcrafterCharacterClassLevel10ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResFearAttribute), "true"),
    };
}
