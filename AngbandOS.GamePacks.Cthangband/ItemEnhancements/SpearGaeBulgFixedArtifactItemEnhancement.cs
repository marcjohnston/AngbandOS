namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpearGaeBulgFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "13"),
        (nameof(MeleeToHitAttribute), "11"),
        (nameof(ValueAttribute), "30000"),
        (nameof(StealthAttribute), "3"),
        (nameof(SpeedAttribute), "3"),
        (nameof(InfravisionAttribute), "3"),
    };
    public override bool? BrandCold => true;
    public override string FriendlyName => "'Gae Bulg'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResCold => true;
    public override bool? ResDark => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayUndead => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
