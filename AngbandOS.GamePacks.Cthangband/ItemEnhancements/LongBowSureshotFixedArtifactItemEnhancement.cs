namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongBowSureshotFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "22"),
        (nameof(MeleeToHitAttribute), "20"),
        (nameof(ValueAttribute), "35000"),
        (nameof(StealthAttribute), "3"),
        (nameof(DexterityAttribute), "3"),
    };
    public override string FriendlyName => "'Sureshot'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResDisen => true;
    public override bool? ShowMods => true;
    public override bool? XtraShots => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
