namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AggravateMonsterRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IsCursedAttribute), "true"),
    };
    public override bool? Aggravate => true;
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "-15000"),
    };
    public override string? HatesElectricity => "true";
    public override bool? Valueless => true;
}
