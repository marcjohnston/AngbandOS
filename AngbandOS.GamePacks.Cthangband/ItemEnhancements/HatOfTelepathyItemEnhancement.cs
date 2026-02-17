namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfTelepathyItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "50000"),
        (nameof(TreasureRatingAttribute), "20"),
    };
    public override string? FriendlyName => "of Telepathy";
    public override bool? Telepathy => true;
}
