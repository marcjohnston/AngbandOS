namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LanceSkewerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "21"),
        (nameof(MeleeToHitAttribute), "3"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "55000"),
        (nameof(WeightAttribute), "60"),
        (nameof(DexterityAttribute), "2"),
    };
    public override string FriendlyName => "'Skewer'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
