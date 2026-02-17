namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LiberIvonisSorceryBookItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "30"),
        (nameof(ValueAttribute), "100000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.Blue;
    public override string? HatesFire => "true";
}
