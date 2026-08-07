namespace AngbandOS.GamePacks.Cthangband;

public class WeaponOfKadathItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(SlayGiantAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "20000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "1d5"),
        (nameof(ToDamageAttribute), "1d5"),
        (nameof(BonusDexterityAttribute), "1d2"),
        (nameof(BonusConstitutionAttribute), "1d2"),
        (nameof(BonusStrengthAttribute), "1d2"),
    };
    public override string? FriendlyName => "of Kadath";
}
