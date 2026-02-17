namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfLordlinessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
        (nameof(TreasureRatingAttribute), "17"),
        (nameof(WisdomAttribute), "1d3"),
        (nameof(CharismaAttribute), "1d3"),
    };
    public override string? FriendlyName => "of Lordliness";
    public override bool? SustCha => true;
    public override bool? SustWis => true;
}
