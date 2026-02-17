namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GoldenCrownOfTheSunFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.Heal700Every25Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "3"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(AttacksAttribute), "15"),
        (nameof(ValueAttribute), "125000"),
        (nameof(WisdomAttribute), "3"),
        (nameof(SpeedAttribute), "3"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "of the Sun";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResBlind => true;
    public override bool? ResChaos => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? SeeInvis => true;
    public override bool? Feather => true;
    public override bool? FreeAct => true;
    public override bool? HoldLife => true;
    public override bool? SlowDigest => true;
    public override bool? Telepathy => true;
    public override ColorEnum? Color => ColorEnum.Yellow;
}
