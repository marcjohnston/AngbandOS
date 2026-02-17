namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallMetalShieldVitriolFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(AttacksAttribute), "25"),
        (nameof(ValueAttribute), "60000"),
        (nameof(ConstitutionAttribute), "4"),
        (nameof(StrengthAttribute), "4"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Vitriol'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImAcid => true;
    public override bool? ResChaos => true;
    public override bool? ResSound => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
