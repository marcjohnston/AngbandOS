namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfElementalPowerIceFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.LargeFrostBall200Every325p1d325DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "11"),
        (nameof(MeleeToHitAttribute), "11"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "200000"),
        (nameof(RadiusAttribute), "3"),
        (nameof(WisdomAttribute), "2"),
        (nameof(SpeedAttribute), "2"),
        (nameof(DexterityAttribute), "2"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(CharismaAttribute), "2"),
        (nameof(StrengthAttribute), "2"),
    };
    public override bool? Feather => true;
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Elemental Power (Ice)";
    public override bool? HideType => true;
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImCold => true;
    public override bool? Regen => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SustInt => true;
    public override bool? SustWis => true;
    public override bool? SlowDigest => true;
    public override bool? Telepathy => true;
}
