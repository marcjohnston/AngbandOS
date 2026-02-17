namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpearGungnirFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfLightning100r3Every500DirectionalActivation);
    public override bool? Blessed => true;
    public override bool? BrandElec => true;
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "25"),
        (nameof(MeleeToHitAttribute), "15"),
        (nameof(AttacksAttribute), "5"),
        (nameof(DamageDiceAttribute), "3"),
        (nameof(ValueAttribute), "180000"),
        (nameof(WisdomAttribute), "4"),
        (nameof(IntelligenceAttribute), "4"),
        (nameof(RadiusAttribute), "3"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Gungnir'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? ShowMods => true;
    public override bool? SlayGiant => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override bool? SlowDigest => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
