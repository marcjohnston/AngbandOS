namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordOfEverflameFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfFire72r2Every400DirectionalActivation);
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "15"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(AttacksAttribute), "5"),
        (nameof(ValueAttribute), "80000"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "4"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Everflame";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override bool? SustDex => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
