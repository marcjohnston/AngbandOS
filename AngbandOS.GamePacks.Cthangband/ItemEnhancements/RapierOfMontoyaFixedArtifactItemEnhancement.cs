namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RapierOfMontoyaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "19"),
        (nameof(MeleeToHitAttribute), "12"),
        (nameof(ValueAttribute), "15000"),
        (nameof(RadiusAttribute), "3"),
    };
    public override bool? BrandCold => true;
    public override string FriendlyName => "of Montoya";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResCold => true;
    public override bool? ResLight => true;
    public override bool? ShowMods => true;
    public override bool? SlayAnimal => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
