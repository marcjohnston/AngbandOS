namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GnomeSkeletonSkeletonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "30"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "2"),
    };
    public override ColorEnum? Color => ColorEnum.Beige;
    public override string? HatesAcid => "true";
    public override bool? Valueless => true;
}
