namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PairOfMetalShodBootsOfTheBlackReaverFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "15000"),
        (nameof(SpeedAttribute), "10"),
        (nameof(ConstitutionAttribute), "10"),
        (nameof(StrengthAttribute), "10"),
    };
    public override bool? Aggravate => true;
    public override string FriendlyName => "of the Black Reaver";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
