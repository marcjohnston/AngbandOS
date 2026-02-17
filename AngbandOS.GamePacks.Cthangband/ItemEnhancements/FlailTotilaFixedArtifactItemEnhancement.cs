namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlailTotilaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.ConfuseMonster20Every15DirectionalActivation);
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "8"),
        (nameof(MeleeToHitAttribute), "6"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "55000"),
        (nameof(StealthAttribute), "2"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "'Totila'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResConf => true;
    public override bool? ResFire => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override ColorEnum? Color => ColorEnum.Black;
}
