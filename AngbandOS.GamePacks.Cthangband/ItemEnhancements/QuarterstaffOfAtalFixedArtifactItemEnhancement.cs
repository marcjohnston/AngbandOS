namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class QuarterstaffOfAtalFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.ProbingDetectionAndFullIdEvery1000Activation);
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "13"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "140000"),
        (nameof(WisdomAttribute), "4"),
        (nameof(IntelligenceAttribute), "4"),
        (nameof(CharismaAttribute), "4"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "of Atal";
    public override bool? HideType => true;
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    public override bool? ResNether => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override bool? Feather => true;
    public override bool? FreeAct => true;
    public override bool? Regen => true;
    public override bool? SlowDigest => true;
    public override bool? Telepathy => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
