namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmSkullkeeperFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.DetectionEvery55p1d55Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(AttacksAttribute), "10"),
        (nameof(ValueAttribute), "100000"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "2"),
    };
    public override string FriendlyName => "'Skullkeeper'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResBlind => true;
    public override bool? SeeInvis => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
