namespace AngbandOS.GamePacks.Cthangband;

public class WeaponDefenderItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
        (nameof(FeatherAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
    };
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(SustainItemEnhancementWeightedRandom);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "15000"),
        (nameof(TreasureRatingAttribute), "25"),
        (nameof(MeleeToHitAttribute), "1d4"),
        (nameof(ToDamageAttribute), "1d4"),
        (nameof(BonusArmorClassAttribute), "1d8"),
        (nameof(StealthAttribute), "1d4"),
    };
    public override string? FriendlyName => "(Defender)";
}
