namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class QuarterstaffFirestaffFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "20"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(ValueAttribute), "70000"),
        (nameof(IntelligenceAttribute), "3"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "'Firestaff'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    public override bool? ShowMods => true;
    public override bool? SlayAnimal => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
