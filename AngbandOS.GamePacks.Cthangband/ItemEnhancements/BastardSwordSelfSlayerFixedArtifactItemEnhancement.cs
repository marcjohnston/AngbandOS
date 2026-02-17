namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BastardSwordSelfSlayerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HeavyCurseAttribute), "true"),
        (nameof(IsCursedAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(SlayDragonAttribute), "5"),
        (nameof(ConstitutionAttribute), "5"),
        (nameof(ValueAttribute), "100000"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(MeleeToHitAttribute), "-20"),
        (nameof(ToDamageAttribute), "20"),
    };
    public override bool? Aggravate => true;
    public override string FriendlyName => "'Selfslayer'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResDisen => true;
    public override bool? ShowMods => true;
    public override bool? SlayDemon => true;
    public override bool? SlayEvil => true;
    public override bool? SlayTroll => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
