
namespace AngbandOS.GamePacks.Cthangband;

public class PaladinCharacterClassLevel40ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResFearAttribute), "true"),
    };
}
