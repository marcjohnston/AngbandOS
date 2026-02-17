namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScytheOfGharneFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "8"),
        (nameof(MeleeToHitAttribute), "8"),
        (nameof(AttacksAttribute), "10"),
        (nameof(ValueAttribute), "18000"),
        (nameof(DexterityAttribute), "3"),
        (nameof(CharismaAttribute), "3"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.WordOfRecallEvery200DirectionalActivation);
    public override bool? BrandCold => true;
    public override bool? BrandFire => true;
    public override bool? FreeAct => true;
    public override string FriendlyName => "of G'harne";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResCold => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
