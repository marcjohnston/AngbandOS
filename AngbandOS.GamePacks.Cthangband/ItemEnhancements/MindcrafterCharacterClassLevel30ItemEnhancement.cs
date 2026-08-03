
namespace AngbandOS.GamePacks.Cthangband;

public class MindcrafterCharacterClassLevel30ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResConfAttribute), "true"),
    };
}
