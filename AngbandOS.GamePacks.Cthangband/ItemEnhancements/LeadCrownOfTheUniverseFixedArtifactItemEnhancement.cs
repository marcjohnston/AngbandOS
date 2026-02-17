namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeadCrownOfTheUniverseFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "10000000"),
        (nameof(WisdomAttribute), "125"),
        (nameof(InfravisionAttribute), "125"),
        (nameof(IntelligenceAttribute), "125"),
        (nameof(DexterityAttribute), "125"),
        (nameof(ConstitutionAttribute), "125"),
        (nameof(CharismaAttribute), "125"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "125"),
    };
    public override bool? IsCursed => true;
    public override string FriendlyName => "of the Universe";
    public override bool? HeavyCurse => true;
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? NoTele => true;
    public override bool? PermaCurse => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResConf => true;
    public override bool? ResDark => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? ResNexus => true;
    public override bool? ResPois => true;
    public override bool? SeeInvis => true;
    public override bool? Telepathy => true;
    public override ColorEnum? Color => ColorEnum.Black;
}
