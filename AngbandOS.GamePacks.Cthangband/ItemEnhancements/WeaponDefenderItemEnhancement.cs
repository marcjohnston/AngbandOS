namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponDefenderItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(SustainItemEnhancementWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "15000"),
        (nameof(TreasureRatingAttribute), "25"),
        (nameof(MeleeToHitAttribute), "1d4"),
        (nameof(ToDamageAttribute), "1d4"),
        (nameof(BonusArmorClassAttribute), "1d8"),
        (nameof(StealthAttribute), "1d4"),
    };
    public override bool? Feather => true;
    public override bool? FreeAct => true;
    public override string? FriendlyName => "(Defender)";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? SeeInvis => true;
}
