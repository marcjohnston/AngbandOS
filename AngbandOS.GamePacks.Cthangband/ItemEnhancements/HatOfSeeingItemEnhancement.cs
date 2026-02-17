namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfSeeingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1000"),
        (nameof(TreasureRatingAttribute), "8"),
        (nameof(SearchAttribute), "1d5"),
    };
    public override string? FriendlyName => "of Seeing";
    public override bool? ResBlind => true;
    public override bool? SeeInvis => true;
}
