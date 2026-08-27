namespace AngbandOS.GamePacks.Cthangband;

public class HalfTrollRaceLevel15ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
        (nameof(SlowDigestAttribute), "true")
    };
}