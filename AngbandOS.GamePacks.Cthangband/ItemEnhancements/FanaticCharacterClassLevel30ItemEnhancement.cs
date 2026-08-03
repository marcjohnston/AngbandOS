
namespace AngbandOS.GamePacks.Cthangband;

public class FanaticCharacterClassLevel30ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResChaosAttribute), "true"),
    };
}
