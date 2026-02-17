namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LucerneHammerJusticeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(RadiusAttribute), "3"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(InfravisionAttribute), "4"),
        (nameof(ToDamageAttribute), "6"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(AttacksAttribute), "8"),
        (nameof(ValueAttribute), "30000"),
        (nameof(WisdomAttribute), "4"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.DrainLife90Every70DirectionalActivation);
    public override bool? BrandCold => true;
    public override string FriendlyName => "'Justice'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResCold => true;
    public override bool? ResLight => true;
    public override bool? ShowMods => true;
    public override bool? SlayOrc => true;
    public override ColorEnum? Color => ColorEnum.BrightBlue;
}
