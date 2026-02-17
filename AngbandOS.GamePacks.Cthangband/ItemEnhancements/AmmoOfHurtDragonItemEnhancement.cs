namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfHurtDragonItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "35"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(SlayDragonAttribute), "3"),
    };
    public override string? FriendlyName => "of Hurt Dragon";
}
