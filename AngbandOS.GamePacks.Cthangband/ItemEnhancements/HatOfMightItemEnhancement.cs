namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfMightItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
        (nameof(TreasureRatingAttribute), "19"),
        (nameof(WisdomAttribute), "1d3"),
        (nameof(StrengthAttribute), "1d3")
    };
    public override bool? FreeAct => true;
    public override string? FriendlyName => "of Might";
    public override bool? SustCon => true;
    public override bool? SustDex => true;
    public override bool? SustStr => true;
}
