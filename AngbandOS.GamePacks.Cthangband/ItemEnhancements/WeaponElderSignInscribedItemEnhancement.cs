namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponElderSignInscribedItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(SustainItemEnhancementWeightedRandom);
    public override bool? Blessed => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "20000"),
        (nameof(TreasureRatingAttribute), "30"),
        (nameof(MeleeToHitAttribute), "1d6"),
        (nameof(ToDamageAttribute), "1d6"),
        (nameof(BonusArmorClassAttribute), "1d4"),
        (nameof(WisdomAttribute), "1d4"),
    };
    public override string? FriendlyName => "(Elder Sign Inscribed)";
    public override bool? ResFear => true;
    public override bool? SeeInvis => true;
    public override bool? SlayDemon => true;
    public override bool? SlayEvil => true;
    public override bool? SlayUndead => true;
}
