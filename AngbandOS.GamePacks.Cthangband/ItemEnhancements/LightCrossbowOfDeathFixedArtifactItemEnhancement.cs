namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightCrossbowOfDeathFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BrandBoltsEvery999Activation);
    public override string FriendlyName => "of Death";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(SpeedAttribute), "10"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "14"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(ValueAttribute), "50000"),
    };
    public override bool? ResFire => true;
    public override bool? ShowMods => true;
    public override bool? XtraMight => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
