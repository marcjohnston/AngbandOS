namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfInfravisionItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "500"),
        (nameof(TreasureRatingAttribute), "11"),
        (nameof(InfravisionAttribute), "1d5"),
    };
    public override string? FriendlyName => "of Infravision";
    public override bool? HideType => true;
}
