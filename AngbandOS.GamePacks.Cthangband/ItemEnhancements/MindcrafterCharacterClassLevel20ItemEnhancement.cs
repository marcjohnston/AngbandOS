
namespace AngbandOS.GamePacks.Cthangband;

public class MindcrafterCharacterClassLevel20ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustWisAttribute), "true"),
    };
}
