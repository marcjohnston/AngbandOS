namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfUndeadBaneItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SeeInvisAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "8000"),
        (nameof(TreasureRatingAttribute), "24"),
        (nameof(WisdomAttribute), "1d2"),
    };
    public override string? FriendlyName => "of Undead Bane";
}
