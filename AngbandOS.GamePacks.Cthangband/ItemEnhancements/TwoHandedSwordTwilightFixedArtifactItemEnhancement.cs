namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordTwilightFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "-60"),
        (nameof(MeleeToHitAttribute), "-40"),
        (nameof(AttacksAttribute), "-50"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "40000"),
        (nameof(WeightAttribute), "50"),
        (nameof(SpeedAttribute), "10"),
        (nameof(RadiusAttribute), "3"),
    };
    public override bool? Aggravate => true;
    public override bool? BrandFire => true;
    public override bool? IsCursed => true;
    public override bool? DreadCurse => true;
    public override string FriendlyName => "'Twilight'";
    public override bool? HeavyCurse => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ImFire => true;
    public override bool? ResDisen => true;
    public override bool? ResFear => true;
    public override bool? ResFire => true;
    public override bool? ShowMods => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
