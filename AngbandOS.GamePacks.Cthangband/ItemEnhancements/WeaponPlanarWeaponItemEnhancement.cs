namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponPlanarWeaponItemEnhancement : ItemEnhancementGameConfiguration
{
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
    public override bool? FreeAct => true;
    public override string? FriendlyName => "(Planar Weapon)";
    public override bool? Regen => true;
    public override bool? ResNexus => true;
    public override bool? SlayEvil => true;
    public override bool? SlowDigest => true;
    public override bool? Teleport => true;
}
