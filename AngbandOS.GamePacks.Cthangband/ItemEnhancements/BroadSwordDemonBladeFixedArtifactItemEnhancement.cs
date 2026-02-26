namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordDemonBladeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
    };
    public override string FriendlyName => "'Demon Blade'";
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
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
