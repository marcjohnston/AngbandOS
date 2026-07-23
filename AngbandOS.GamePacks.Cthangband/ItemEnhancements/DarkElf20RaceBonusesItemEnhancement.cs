namespace AngbandOS.GamePacks.Cthangband;

public class DarkElf20RaceBonusesItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SeeInvisAttribute), "true"),
    };
}
