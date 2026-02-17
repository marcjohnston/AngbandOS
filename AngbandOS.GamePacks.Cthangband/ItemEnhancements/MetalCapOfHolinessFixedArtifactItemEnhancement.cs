namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalCapOfHolinessFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "12"),
        (nameof(ValueAttribute), "22000"),
        (nameof(WisdomAttribute), "3"),
        (nameof(CharismaAttribute), "3"),
    };
    public override string FriendlyName => "of Holiness";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
