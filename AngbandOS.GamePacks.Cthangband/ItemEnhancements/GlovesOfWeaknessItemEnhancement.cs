namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GlovesOfWeaknessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ValuelessAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
  {
        (nameof(StrengthAttribute), "1d10")
  };
    public override string? FriendlyName => "of Weakness";
}
