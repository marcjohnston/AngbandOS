namespace AngbandOS.GamePacks.Cthangband;

public class GlovesOfWeaknessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
  {
        (nameof(BonusStrengthAttribute), "1d10")
  };
    public override string? FriendlyName => "of Weakness";
}
