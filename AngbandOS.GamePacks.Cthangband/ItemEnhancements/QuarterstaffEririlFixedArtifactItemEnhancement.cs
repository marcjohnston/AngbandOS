namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class QuarterstaffEririlFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(RadiusAttribute), "3"),
        (nameof(ToDamageAttribute), "5"),
        (nameof(MeleeToHitAttribute), "3"),
        (nameof(ValueAttribute), "20000"),
        (nameof(WisdomAttribute), "4"),
        (nameof(IntelligenceAttribute), "4"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.IdentifyEvery10Activation);
    public override string FriendlyName => "'Eriril'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResLight => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
