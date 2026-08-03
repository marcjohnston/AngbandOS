
namespace AngbandOS.GamePacks.Cthangband;

public class CultistCharacterClassLevel20ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResChaosAttribute), "true"),
    };
}
