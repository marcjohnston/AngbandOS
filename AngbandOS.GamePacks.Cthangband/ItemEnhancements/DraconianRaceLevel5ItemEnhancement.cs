namespace AngbandOS.GamePacks.Cthangband;

public class DraconianRaceLevel5ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResFireAttribute), "true")
    };
}
