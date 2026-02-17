namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfElementalPowerFireFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.FireBall120r3Every225p1d225DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "1"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "10"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "100000"),
        (nameof(WisdomAttribute), "1"),
        (nameof(SpeedAttribute), "1"),
        (nameof(IntelligenceAttribute), "1"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ConstitutionAttribute), "1"),
        (nameof(CharismaAttribute), "1"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Elemental Power (Fire)";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImFire => true;
    public override bool? Regen => true;
    public override bool? SeeInvis => true;
    public override bool? SlowDigest => true;
    public override bool? SustDex => true;
    public override bool? SustStr => true;
}
