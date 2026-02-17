namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfKadathItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(SlayGiantAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "20000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "1d5"),
        (nameof(ToDamageAttribute), "1d5"),
        (nameof(DexterityAttribute), "1d2"),
        (nameof(ConstitutionAttribute), "1d2"),
        (nameof(StrengthAttribute), "1d2"),
    };
    public override string? FriendlyName => "of Kadath";
}
