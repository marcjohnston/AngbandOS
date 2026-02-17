namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerOfAssassinFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? BrandPois => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(DexterityAttribute), "4"),
        (nameof(SearchAttribute), "4"),
        (nameof(StealthAttribute), "4"),
        (nameof(ValueAttribute), "125000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(AttacksAttribute), "5"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(ToDamageAttribute), "15"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Assassin";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResDark => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override bool? SustDex => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
