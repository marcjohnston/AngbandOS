namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordDemonBladeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Aggravate => true;
    public override string FriendlyName => "'Demon Blade'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(AttacksAttribute), "2"),
        (nameof(SpeedAttribute), "2"),
        (nameof(StealthAttribute), "2"),
        (nameof(WeightAttribute), "-20"),
        (nameof(Vorpal1InChanceAttribute), "6"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(ValueAttribute), "66666"),
        (nameof(DamageDiceAttribute), "9"),
        (nameof(MeleeToHitAttribute), "-30"),
        (nameof(ToDamageAttribute), "7"),
        (nameof(DexterityAttribute), "2"),
        (nameof(CharismaAttribute), "2"),
    };
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
