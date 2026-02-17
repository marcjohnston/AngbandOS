namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BowOfVelocityItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1000"),
        (nameof(ToDamageAttribute), "1d15"),
        (nameof(MeleeToHitAttribute), "1d5"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Velocity";
}
