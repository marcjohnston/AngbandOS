namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceOfDisruptionDeathwreakerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Aggravate => true;
    public override bool? BrandFire => true;
    public override bool? BrandPois => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "18"),
        (nameof(MeleeToHitAttribute), "18"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(DamageDiceAttribute), "5"),
        (nameof(ValueAttribute), "444444"),
        (nameof(WeightAttribute), "280"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(TunnelAttribute), "6"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "6"),
    };
    public override string FriendlyName => "'Deathwreaker'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImFire => true;
    public override bool? NoTele => true;
    public override bool? ResChaos => true;
    public override bool? ResDark => true;
    public override bool? ResDisen => true;
    public override bool? ShowMods => true;
    public override bool? SlayAnimal => true;
    public override bool? SlayEvil => true;
    public override bool? SlayUndead => true;
    public override bool? Vampiric => true;
    public override ColorEnum? Color => ColorEnum.Purple;
}
