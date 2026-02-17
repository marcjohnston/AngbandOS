namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponPlanarWeaponItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(RegenAttribute), "true"),
        (nameof(ResNexusAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
        (nameof(TeleportAttribute), "true"),
    };
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(AbilityItemEnhancementWeightedRandom);
    public override string? ActivationName => nameof(ActivationsEnum.Teleport100Every1d50p50Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "7000"),
        (nameof(TreasureRatingAttribute), "22"),
        (nameof(MeleeToHitAttribute), "1d4"),
        (nameof(ToDamageAttribute), "1d4"),
        (nameof(SearchAttribute), "1d2"),
    };
    public override string? FriendlyName => "(Planar Weapon)";
}
