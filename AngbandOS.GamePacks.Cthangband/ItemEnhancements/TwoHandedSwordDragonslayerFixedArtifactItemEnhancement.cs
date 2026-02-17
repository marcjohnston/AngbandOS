namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordDragonslayerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(RegenAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "17"),
        (nameof(MeleeToHitAttribute), "13"),
        (nameof(ValueAttribute), "100000"),
        (nameof(SlayDragonAttribute), "5"),
        (nameof(StrengthAttribute), "2"),
    };
    public override string FriendlyName => "'Dragonslayer'";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
