namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerHopeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "11000"),
        (nameof(MeleeToHitAttribute), "4"),
        (nameof(ToDamageAttribute), "6"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.FrostBolt6d8Every7p1d7DirectionalActivation);

    public override bool? BrandCold => true;
    public override string FriendlyName => "'Hope'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResCold => true;
    public override bool? ShowMods => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
