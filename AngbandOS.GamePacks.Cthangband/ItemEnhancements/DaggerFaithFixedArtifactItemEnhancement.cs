namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerFaithFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(RadiusAttribute), "3"),
        (nameof(ValueAttribute), "12000"),
        (nameof(MeleeToHitAttribute), "4"),
        (nameof(ToDamageAttribute), "6"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.FireBolt9d8Every8p1d8DirectionalActivation);
    public override bool? BrandFire => true;
    public override string FriendlyName => "'Faith'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    public override bool? ShowMods => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
