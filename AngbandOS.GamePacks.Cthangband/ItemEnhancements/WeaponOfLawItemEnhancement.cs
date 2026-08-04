namespace AngbandOS.GamePacks.Cthangband;

public class WeaponOfLawItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "25000"),
        (nameof(TreasureRatingAttribute), "26"),
        (nameof(MeleeToHitAttribute), "1d6"),
        (nameof(ToDamageAttribute), "1d6"),
        (nameof(ConstitutionAttribute), "1d2"),
        (nameof(StrengthAttribute), "1d2"),
    };
    public override string? FriendlyName => "(Weapon of Law)";
}
