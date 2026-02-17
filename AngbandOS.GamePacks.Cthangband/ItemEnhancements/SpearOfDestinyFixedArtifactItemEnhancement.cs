namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpearOfDestinyFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.StoneToMudDirectionalActivation);
    public override bool? Blessed => true;
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "15"),
        (nameof(MeleeToHitAttribute), "15"),
        (nameof(ValueAttribute), "77777"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(WisdomAttribute), "4"),
        (nameof(IntelligenceAttribute), "4"),
        (nameof(InfravisionAttribute), "4"),
        (nameof(RadiusAttribute), "3"),
    };
    public override bool? Feather => true;
    public override string FriendlyName => "of Destiny";
    public override bool? HideType => true;
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFear => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayDemon => true;
    public override bool? SlayEvil => true;
    public override bool? SlayGiant => true;
    public override bool? SlayUndead => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
