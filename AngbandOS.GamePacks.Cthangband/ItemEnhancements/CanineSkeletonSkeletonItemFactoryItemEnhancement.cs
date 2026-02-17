namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CanineSkeletonSkeletonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "10"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.Beige;
    public override string? HatesAcid => "true";
    public override bool? Valueless => true;
}
