namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponElderSignInscribedItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BlessedAttribute), "true"),
        (nameof(ResFearAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
    };
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(SustainItemEnhancementWeightedRandom);
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
}
