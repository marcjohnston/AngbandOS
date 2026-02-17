namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedFlailThunderfistFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandElec => true;
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "18"),
        (nameof(MeleeToHitAttribute), "5"),
        (nameof(ValueAttribute), "160000"),
        (nameof(WeightAttribute), "20"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "4"),
    };
    public override string FriendlyName => "'Thunderfist'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResDark => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ShowMods => true;
    public override bool? SlayAnimal => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override ColorEnum? Color => ColorEnum.Yellow;
}
