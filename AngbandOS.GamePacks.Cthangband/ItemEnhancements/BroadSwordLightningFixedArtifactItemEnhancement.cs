namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordLightningFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandElec => true;
    public override string FriendlyName => "'Lightning'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(SlayDragonAttribute), "15"),
        (nameof(RadiusAttribute), "3"),
        (nameof(ValueAttribute), "95000"),
        (nameof(SearchAttribute), "4"),
        (nameof(MeleeToHitAttribute), "12"),
        (nameof(ToDamageAttribute), "16"),
    };
    public override bool? ResElec => true;
    public override bool? ResFear => true;
    public override bool? ResFire => true;
    public override bool? ResPois => true;
    public override bool? ShowMods => true;
    public override bool? SlayOrc => true;
    public override bool? SlowDigest => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
