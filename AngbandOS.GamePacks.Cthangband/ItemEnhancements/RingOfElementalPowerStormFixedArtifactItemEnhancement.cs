namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfElementalPowerStormFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.LargeLightningBall250Every425p1d425DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "12"),
        (nameof(MeleeToHitAttribute), "12"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "300000"),
        (nameof(RadiusAttribute), "3"),
        (nameof(WisdomAttribute), "3"),
        (nameof(SpeedAttribute), "3"),
        (nameof(IntelligenceAttribute), "3"),
        (nameof(DexterityAttribute), "3"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(CharismaAttribute), "3"),
        (nameof(StrengthAttribute), "3"),
    };
    public override bool? Feather => true;
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Elemental Power (Storm)";
    public override bool? HideType => true;
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImElec => true;
    public override bool? Regen => true;
    public override bool? SeeInvis => true;
    public override bool? SlowDigest => true;
    public override bool? SustDex => true;
    public override bool? SustInt => true;
    public override bool? SustStr => true;
    public override bool? SustWis => true;
    public override bool? Telepathy => true;
}
