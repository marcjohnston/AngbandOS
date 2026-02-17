namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PintOfFineAleFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "5"),
        (nameof(ValueAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.Yellow;
}
